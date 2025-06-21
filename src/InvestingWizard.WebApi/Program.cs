using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Application;
using InvestingWizard.Identity.Data.Contexts;
using InvestingWizard.Identity.Data.Models;
using InvestingWizard.Identity.Services;
using InvestingWizard.Identity;
using InvestingWizard.Infrastructure;
using InvestingWizard.Infrastructure.Logging;
using InvestingWizard.Infrastructure.Services;
using InvestingWizard.Infrastructure.Services.Mappers;
using InvestingWizard.Infrastructure.Settings;
using InvestingWizard.TradingAssistant.Algorithms;
using InvestingWizard.TradingAssistant.Clients.AlphaVantage;
using InvestingWizard.TradingAssistant.Clients.OpenAI;
using InvestingWizard.TradingAssistant.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Serilog;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddSingleton(Log.Logger);
builder.Services.AddSingleton<ILoggingService, SerilogLoggingService>();

builder.Services.AddScoped<IEntityMapper, EntityMapper>();
builder.Services.AddMemoryCache();
builder.Services.AddHostedService<CacheUpdaterService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();

builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<ExternalApiService>();
builder.Services.AddScoped<IExternalApiService, ExternalApiService>();
builder.Services.AddHttpClient<IExternalApiService, ExternalApiService>();
builder.Services.Configure<ExternalApiSettings>(builder.Configuration.GetSection("ExternalApiSettings"));

builder.Services.AddScoped<IPriceUpdateService, PriceUpdateService>();
builder.Services.AddScoped<ITimeZoneService, TimeZoneService>();
builder.Services.AddScoped<ICachedPricesService, CachedPricesService>();
builder.Services.AddScoped<ITransactionOrchestrationService, TransactionOrchestrationService>();
builder.Services.AddScoped<IDividendOrchestrationService, DividendOrchestrationService>();
builder.Services.AddSingleton<IHostedService, CacheUpdaterService>();
builder.Services.AddSingleton<OptimizationAlgorithm>();

builder.Services.Configure<AlphaVantageSettings>(builder.Configuration.GetSection("AlphaVantageSettings"));
builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection("OpenAISettings"));

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

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddAntiforgery();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<ApplicationUserManager>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<QrCodeService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.MapControllers();

app.Run();
