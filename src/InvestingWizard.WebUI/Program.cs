using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Identity.Data.Initializers;
using InvestingWizard.Application;
using InvestingWizard.Identity.Services;
using InvestingWizard.Infrastructure;
using InvestingWizard.Identity;
using InvestingWizard.Identity.Data.Contexts;
using InvestingWizard.Identity.Data.Models;
using InvestingWizard.Infrastructure.Services;
using InvestingWizard.Infrastructure.Services.Mappers;
using InvestingWizard.WebUI.Components;
using InvestingWizard.WebUI.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Syncfusion.Blazor;
using InvestingWizard.Infrastructure.Settings;
using System.Reflection;
using InvestingWizard.Infrastructure.Middleware;
using InvestingWizard.Infrastructure.Logging;
using InvestingWizard.TradingAssistant.Algorithms;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using InvestingWizard.TradingAssistant.Clients.AlphaVantage;
using InvestingWizard.TradingAssistant.Clients.OpenAI;
using InvestingWizard.TradingAssistant.Settings;
using InvestingWizard.WebUI.Interfaces;
using InvestingWizard.WebUI.Services;

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

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
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

builder.Services.AddSingleton<OptimizationAlgorithm>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddScoped<IAdminDataService, AdminDataService>();
builder.Services.AddScoped<IExchangeDataService, ExchangeDataService>();
builder.Services.AddScoped<IPortfolioDataService, PortfolioDataService>();
builder.Services.AddScoped<IWatchlistDataService, WatchlistDataService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddApplicationServices();

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

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<ApplicationUserManager>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddAntiforgery();

builder.Services.AddSingleton<QrCodeService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API", Version = "v1" });
});

builder.Services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });
builder.Services.AddTransient<DbInitializer>();

var app = builder.Build();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["Syncfusion:LicenseKey"]);

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"));

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseSerilogRequestLogging();
app.UseMiddleware<RequestLogContextMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();

        var initializer = services.GetRequiredService<DbInitializer>();
        await initializer.SeedRolesAsync();
        await initializer.SeedAdminAsync();

        Log.Information("Seeding Db successfully");
    }
    catch (Exception ex)
    {
        Log.Error("An error occurred seeding the Db. Exception: {ExceptionMessage}", ex.Message);
    }
}

app.MapGroup("/auth").MapIdentityApi<ApplicationUser>();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.MapControllers();

app.Run();
