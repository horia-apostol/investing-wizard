using InvestingWizard.TradingAssistant.Algorithms;
using InvestingWizard.TradingAssistant.Clients.AlphaVantage;
using InvestingWizard.TradingAssistant.Clients.OpenAI;
using InvestingWizard.TradingAssistant.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<OptimizationAlgorithm>();

builder.Services.AddHttpClient<AlphaVantageClient>((serviceProvider, client) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<AlphaVantageSettings>>().Value;
    client.BaseAddress = new Uri("https://www.alphavantage.co");
});

builder.Services.AddHttpClient<OpenAIClient>((serviceProvider, client) =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<OpenAISettings>>().Value;
    client.BaseAddress = new Uri("https://api.openai.com");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.ApiKey);
});

builder.Services.Configure<AlphaVantageSettings>(builder.Configuration.GetSection("AlphaVantageSettings"));
builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection("OpenAISettings"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
