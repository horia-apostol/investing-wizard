using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class EarningsTrendExternalDto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("period")]
        public string? Period { get; set; }
        [JsonPropertyName("growth")]
        public string? Growth { get; set; }
        [JsonPropertyName("earningsEstimateAvg")]
        public string? EarningsEstimateAvg { get; set; }
        [JsonPropertyName("earningsEstimateLow")]
        public string? EarningsEstimateLow { get; set; }
        [JsonPropertyName("earningsEstimateHigh")]
        public string? EarningsEstimateHigh { get; set; }
        [JsonPropertyName("earningsEstimateYearAgoEps")]
        public string? EarningsEstimateYearAgoEps { get; set; }
        [JsonPropertyName("earningsEstimateNumberOfAnalysts")]
        public string? EarningsEstimateNumberOfAnalysts { get; set; }
        [JsonPropertyName("earningsEstimateGrowth")]
        public string? EarningsEstimateGrowth { get; set; }
        [JsonPropertyName("revenueEstimateAvg")]
        public string? RevenueEstimateAvg { get; set; }
        [JsonPropertyName("revenueEstimateLow")]
        public string? RevenueEstimateLow { get; set; }
        [JsonPropertyName("revenueEstimateHigh")]
        public string? RevenueEstimateHigh { get; set; }
        [JsonPropertyName("revenueEstimateYearAgoEps")]
        public string? RevenueEstimateYearAgoEps { get; set; }
        [JsonPropertyName("revenueEstimateNumberOfAnalysts")]
        public string? RevenueEstimateNumberOfAnalysts { get; set; }
        [JsonPropertyName("revenueEstimateGrowth")]
        public string? RevenueEstimateGrowth { get; set; }
        [JsonPropertyName("epsTrendCurrent")]
        public string? EpsTrendCurrent { get; set; }
        [JsonPropertyName("epsTrend7daysAgo")]
        public string? EpsTrend7daysAgo { get; set; }
        [JsonPropertyName("epsTrend30daysAgo")]
        public string? EpsTrend30daysAgo { get; set; }
        [JsonPropertyName("epsTrend60daysAgo")]
        public string? EpsTrend60daysAgo { get; set; }
        [JsonPropertyName("epsTrend90daysAgo")]
        public string? EpsTrend90daysAgo { get; set; }
        [JsonPropertyName("epsRevisionsUpLast7days")]
        public string? EpsRevisionsUpLast7days { get; set; }
        [JsonPropertyName("epsRevisionsUpLast30days")]
        public string? EpsRevisionsUpLast30days { get; set; }
        [JsonPropertyName("epsRevisionsDownLast7days")]
        public string? EpsRevisionsDownLast7days { get; set; }
        [JsonPropertyName("epsRevisionsDownLast30days")]
        public string? EpsRevisionsDownLast30days { get; set; }
    }
}