﻿using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System.Threading.Tasks;

namespace InvestingWizard.Infrastructure.Middleware
{
    public class RequestLogContextMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
            {
                await _next(context);
            }
        }
    }
}
