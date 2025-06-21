using InvestingWizard.Shared.Common;
using InvestingWizard.TradingAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestingWizard.TradingAssistant.Algorithms
{
    public class OptimizationAlgorithm
    {
        public GetSuggestionsResponse SuggestOptimization(
            List<TransactionModel> transactions,
            Dictionary<string, decimal> currentPrices,
            Guid targetTransactionId,
            decimal? unitsToClose = null,
            decimal spread = 0,
            decimal taxRate = 0.10m)
        {
            var response = new GetSuggestionsResponse
            {
                Information = [],
                Suggestions = []
            };

            var targetTransaction = transactions.FirstOrDefault(t => t.Id == targetTransactionId);
            if (targetTransaction == null)
                return response;

            var exchangeRate = targetTransaction.AmountInUserCurrency / (targetTransaction.UnitPrice * targetTransaction.Units);

            var effectiveUnits = unitsToClose ?? targetTransaction.Units;
            decimal targetProfit = (currentPrices[targetTransaction.SecurityCode] - targetTransaction.UnitPrice) * effectiveUnits * exchangeRate;

            if (targetTransaction.BrokerIsResident)
            {
                decimal taxRateAtSource = (DateTime.Now - targetTransaction.Date.ToDateTime(TimeOnly.MinValue)).TotalDays <= 365 ? 0.03m : 0.01m;
                decimal taxToPay = targetProfit * taxRateAtSource;

                response.Information.Add(new SuggestionDto
                {
                    Message = $"Closing {effectiveUnits:N2} units of {targetTransaction.SecurityCode} at {currentPrices[targetTransaction.SecurityCode]:N2} will result in a profit of {targetProfit:N2} RON. " +
                              $"You should be taxed at source with {taxRateAtSource:P0}, which means {taxToPay:N2} RON."
                });
            }
            else
            {
                response.Information.Add(new SuggestionDto
                {
                    Message = $"Closing {effectiveUnits:N2} units of {targetTransaction.SecurityCode} at {currentPrices[targetTransaction.SecurityCode]:N2} will result in a profit of {targetProfit:N2} RON."
                });

                decimal taxToPay = targetProfit * taxRate;
                response.Information.Add(new SuggestionDto
                {
                    Message = $"Tax to pay: {taxToPay:N2} RON."
                });

                decimal totalProfit = targetProfit;
                decimal totalTaxSavings = 0;

                var sortedTransactions = transactions
                    .Where(t => t.Id != targetTransactionId && !t.BrokerIsResident && t.TransactionCurrencyCode == targetTransaction.TransactionCurrencyCode)
                    .OrderByDescending(t => (t.UnitPrice - currentPrices[t.SecurityCode]) * exchangeRate)
                    .ToList();

                foreach (var transaction in sortedTransactions)
                {
                    decimal lossPerUnit = (transaction.UnitPrice - currentPrices[transaction.SecurityCode]) * exchangeRate;
                    if (lossPerUnit <= 0) continue;

                    decimal unitsToSell = Math.Min(transaction.Units, totalProfit / lossPerUnit);

                    if (unitsToSell >= 0.01m)
                    {
                        decimal netSavings = unitsToSell * lossPerUnit * taxRate;

                        if (netSavings > 0)
                        {
                            response.Suggestions.Add(new SuggestionDto
                            {
                                Message = $"Close {unitsToSell:N2} units of {transaction.SecurityCode} from the highlighted transactions to realize a loss and immediately buy back the same amount.",
                                TransactionId = transaction.Id
                            });
                            totalProfit -= unitsToSell * lossPerUnit;
                            totalTaxSavings += netSavings;
                        }

                        if (totalProfit <= 0) break;
                    }
                }

                response.Information.Add(new SuggestionDto { Message = $"Total tax savings: {totalTaxSavings:N2} RON" });
            }

            return response;
        }
    }
}
