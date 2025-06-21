using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using InvestingWizard.TradingAssistant.Settings;
using Microsoft.Extensions.Options;

namespace InvestingWizard.TradingAssistant.Clients.AlphaVantage
{
    public class AlphaVantageClient(HttpClient httpClient, IOptions<AlphaVantageSettings> settings)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly AlphaVantageSettings _settings = settings.Value;

        public async Task<List<NewsArticle>> GetNewsAndSentimentAsync(string symbol)
        {
            string url = $"/query?function=NEWS_SENTIMENT&tickers={symbol}&apikey={"demo"/*_settings.ApiKey*/}";
            var response = await _httpClient.GetStringAsync(url);

            var newsArticles = new List<NewsArticle>();

            using (JsonDocument jsonDocument = JsonDocument.Parse(response))
            {
                if (jsonDocument.RootElement.TryGetProperty("feed", out JsonElement feed))
                {
                    foreach (var item in feed.EnumerateArray())
                    {
                        var tickerSentiments = item.GetTickerSentiments();
                        var tickerSentiment = tickerSentiments.FirstOrDefault(ts => ts.Ticker == symbol);

                        if (tickerSentiment != null)
                        {
                            var article = new NewsArticle
                            {
                                Title = item.GetPropertyOrDefault("title"),
                                Url = item.GetPropertyOrDefault("url"),
                                Summary = item.GetPropertyOrDefault("summary"),
                                TickerSentiment = tickerSentiment.TickerSentimentLabel
                            };
                            newsArticles.Add(article);
                        }
                    }
                }
            }

            return newsArticles;
        }
    }

    public class NewsArticle
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string TickerSentiment { get; set; }
    }

    public class TickerSentiment
    {
        public string Ticker { get; set; }
        public string RelevanceScore { get; set; }
        public string TickerSentimentScore { get; set; }
        public string TickerSentimentLabel { get; set; }
    }

    public static class JsonElementExtensions
    {
        public static string GetPropertyOrDefault(this JsonElement element, string propertyName, string defaultValue = "")
        {
            if (element.TryGetProperty(propertyName, out JsonElement property))
            {
                return property.GetString();
            }
            return defaultValue;
        }

        public static List<TickerSentiment> GetTickerSentiments(this JsonElement element)
        {
            var list = new List<TickerSentiment>();
            if (element.TryGetProperty("ticker_sentiment", out JsonElement property))
            {
                foreach (var item in property.EnumerateArray())
                {
                    var sentiment = new TickerSentiment
                    {
                        Ticker = item.GetPropertyOrDefault("ticker"),
                        RelevanceScore = item.GetPropertyOrDefault("relevance_score"),
                        TickerSentimentScore = item.GetPropertyOrDefault("ticker_sentiment_score"),
                        TickerSentimentLabel = item.GetPropertyOrDefault("ticker_sentiment_label")
                    };
                    list.Add(sentiment);
                }
            }
            return list;
        }
    }
}
