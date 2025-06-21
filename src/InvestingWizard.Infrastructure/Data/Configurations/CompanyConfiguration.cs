using InvestingWizard.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvestingWizard.Infrastructure.Data.Configurations
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Code);

            builder.Property(c => c.ExchangeCode);
            builder.Property(c => c.Name);
            builder.Property(c => c.Ticker);

            builder.OwnsOne(c => c.GeneralInformation, a => { a.WithOwner(); });
            builder.OwnsOne(c => c.Highlights, a => { a.WithOwner(); });
            builder.OwnsOne(c => c.Valuation, v =>
            {
                v.WithOwner();
            });
            builder.OwnsOne(c => c.SharesStats, s =>
            {
                s.WithOwner();
            });
            builder.OwnsOne(c => c.Technicals, t =>
            {
                t.WithOwner();
            });
            builder.OwnsOne(c => c.SplitsDividends, sd =>
            {
                sd.WithOwner();
            });
            builder.OwnsOne(c => c.AnalystRatings, a => { a.WithOwner(); });
            builder.OwnsOne(c => c.Holders, h =>
            {
                h.WithOwner();
                h.OwnsMany(h => h.Funds, f =>
                {
                    f.WithOwner();
                });
                h.OwnsMany(h => h.Institutions, i =>
                {
                    i.WithOwner();
                });
            });
            builder.OwnsOne(c => c.InsiderTransactions, it =>
            {
                it.OwnsMany(it => it.Transactions, s =>
                {
                    s.WithOwner();
                });
            });
            builder.OwnsOne(c => c.EsgScores, esg =>
            {
                esg.WithOwner();
                esg.OwnsMany(e => e.ActivitiesInvolvement, a =>
                {
                    a.WithOwner();
                });
            });
            builder.OwnsOne(c => c.OutstandingShares, os =>
            {
                os.WithOwner();
                os.OwnsMany(o => o.AnnualShares, oh =>
                {
                    oh.WithOwner();
                });
                os.OwnsMany(o => o.QuarterlyShares, oh =>
                {
                    oh.WithOwner();
                });
            });
            builder.OwnsOne(c => c.Earnings, earnings =>
            {
                earnings.WithOwner();
                earnings.OwnsMany(e => e.EarningsAnnuals, ea =>
                {
                    ea.WithOwner();
                });
                earnings.OwnsMany(e => e.EarningsHistories, ea =>
                {
                    ea.WithOwner();
                });
                earnings.OwnsMany(e => e.EarningsTrends, ea =>
                {
                    ea.WithOwner();
                });
            });
            builder.OwnsOne(c => c.Financials, f =>
            {
                f.OwnsOne(f => f.BalanceSheet, bs =>
                {
                    bs.OwnsMany(b => b.YearlyBalanceSheet);
                    bs.OwnsMany(b => b.QuarterlyBalanceSheet);
                });
                f.OwnsOne(f => f.CashFlow, cf =>
                {
                    cf.OwnsMany(c => c.YearlyCashFlow);
                    cf.OwnsMany(c => c.QuarterlyCashFlow);
                });
                f.OwnsOne(f => f.IncomeStatement, ist =>
                {
                    ist.OwnsMany(i => i.YearlyIncomeStatement);
                    ist.OwnsMany(i => i.QuarterlyIncomeStatement);
                });
            });
        }
    }
}
