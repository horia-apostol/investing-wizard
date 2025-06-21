using InvestingWizard.TradingAssistant.Algorithms;
using InvestingWizard.TradingAssistant.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestingWizard.TradingAssistant.Controllers
{
    [Route("api/optimization")]
    [ApiController]
    public class OptimizationController(OptimizationAlgorithm optimizationAlgorithm) : ControllerBase
    {
        private readonly OptimizationAlgorithm _optimizationAlgorithm = optimizationAlgorithm;

        [HttpPost("get-suggestions")]
        public IActionResult GetSuggestions([FromBody] GetSuggestionsRequest request)
        {
            var currentPrices = request.CurrentPrices;
            var targetTransactionId = request.TargetTransactionId;

            var suggestions = _optimizationAlgorithm.SuggestOptimization(request.Transactions, currentPrices, targetTransactionId, request.UnitsToClose);

            return Ok(suggestions);
        }
    }

    public class GetSuggestionsRequest
    {
        public List<TransactionModel> Transactions { get; set; }
        public Dictionary<string, decimal> CurrentPrices { get; set; }
        public Guid TargetTransactionId { get; set; }
        public decimal? UnitsToClose { get; set; }
    }
}
