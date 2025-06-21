<div align="center">
  <img src="docs/logo.png" alt="App Architecture Diagram" width="250"/>
</div>

<div align="center"> <img src="https://img.shields.io/badge/.NET-8.0-blueviolet?logo=dotnet" alt=".NET 8" /> <img src="https://img.shields.io/badge/ASP.NET_Core-Backend-blue?logo=dotnet" alt="ASP.NET Core" /> <img src="https://img.shields.io/badge/Blazor-Server-purple?logo=blazor" alt="Blazor" /> <img src="https://img.shields.io/badge/CQRS-MediatR-orange?logo=csharp" alt="CQRS + MediatR" /> <img src="https://img.shields.io/badge/PostgreSQL-Database-336791?logo=postgresql&logoColor=white" alt="PostgreSQL" /> <img src="https://img.shields.io/badge/Entity%20Framework-Core-6DB33F?logo=.net" alt="EF Core" /> <img src="https://img.shields.io/badge/Quartz.NET-Scheduler-ff6600?logo=clockify" alt="Quartz.NET" /> <img src="https://img.shields.io/badge/AutoMapper-Object Mapping-red" alt="AutoMapper" /> <img src="https://img.shields.io/badge/Serilog-Logging-darkblue?logo=serilog" alt="Serilog" /> <img src="https://img.shields.io/badge/Syncfusion-UI Components-blue?logo=syncfusion" alt="Syncfusion" /> <img src="https://img.shields.io/badge/SendGrid-Email API-00b2ff?logo=sendgrid" alt="SendGrid" /> <img src="https://img.shields.io/badge/OpenAI-API-6e6ef4?logo=openai" alt="OpenAI API" /> <img src="https://img.shields.io/badge/AlphaVantage-Market News-green" alt="Alpha Vantage" /> <img src="https://img.shields.io/badge/EODHD-Market Data-yellow" alt="EODHD" /> </div>

# Investing Wizard

**Investing Wizard** is an intelligent financial platform designed to help investors consolidate, analyze, and optimize their portfolios.

Built on a modern .NET stack and structured around Clean Architecture principles, the app combines real-time market data, advanced tax optimization tailored to Romanian laws, and AI-driven features to simplify investment tracking and decision-making.

Whether you're investing through Romanian or international brokers, this platform can act as a **central hub** where all your financial activity is unified, visualized, and enhanced.

---

## A unified platform for real investors

Unlike typical investment trackers, *Investing Wizard* goes beyond basic charts and average returns.

Here’s what it really offers:

- **A single control center for your investments**, regardless of the broker. The system distinguishes between local (Romanian tax-resident) and foreign brokers and applies fiscal logic accordingly.
- **Historical transaction-level tracking**, not just holdings, to compute precise net profit, dividend returns, and average buy/sell values in real time.
- **Tax-loss harvesting** and custom optimization logic based on Romanian tax laws. If you invest through non-resident brokers, the platform helps you minimize taxes via techniques that go far beyond simple recordkeeping.
- **Smart assistant modules** powered by AI. Get financial news summaries, market sentiment breakdowns, and helpful recommendations with context-aware responses.
- **Currency unification**: All your transactions and returns are normalized in RON, using up-to-date FX rates.
- **Blazing-fast performance and secure architecture**, thanks to .NET 8, Blazor Server, PostgreSQL, and MediatR.


## Looking ahead — simulations and predictions

Because the app already stores historical data for thousands of assets (via EODHD APIs), it opens the door to more than just analysis, **it becomes a testing ground for machine learning**:

- You can simulate buying a stock at any moment in the past and calculate its performance in today's terms.
- You can train predictive models using long-term historical price data, then test those models against more recent data to evaluate accuracy.
- These capabilities make *Investing Wizard* ideal for future AI/ML integration focused on forecasting, backtesting, and decision support.

<div align="center">

## See it in action

<a href="https://www.youtube.com/watch?v=yEZoU9rP9EY">
  <img src="https://img.youtube.com/vi/yEZoU9rP9EY/0.jpg" alt="Watch demo" />
</a>


## Tech Stack Overview

| Layer           | Stack / Tools Used                           |
|-----------------|----------------------------------------------|
| Web UI          | Blazor Server, Syncfusion UI, Bootstrap      |
| Backend         | ASP.NET Core 8, CQRS with MediatR, DDD       |
| Database        | PostgreSQL + Entity Framework Core           |
| Caching & Jobs  | IMemoryCache, Quartz.NET                     |
| Logging         | Serilog (structured + request tracing)       |
| AI / News       | OpenAI, Alpha Vantage APIs                   |
| Market Data     | EODHD (Real-time, Historical, Fundamentals)  |
| Email + Auth    | ASP.NET Identity, SendGrid, QR-based 2FA     |

## Architecture Overview

<div align="center">
  <img src="docs/Architecture.jpg" alt="App Architecture Diagram" width="800"/>
</div>

</div>

## Documentation & License

Originally developed as a BSc graduation project by **Apostol Horia-Andrei** in 2024,  
this project originated as a bachelor’s thesis at *"Alexandru Ioan Cuza" University in Iași*.

Download full academic PDF (in Romanian): [InvestingWizard.pdf](docs/InvestingWizard.pdf)
