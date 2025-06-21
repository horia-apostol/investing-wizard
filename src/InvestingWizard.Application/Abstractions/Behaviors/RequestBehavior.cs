using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Abstractions.Behaviors
{
    internal sealed class RequestBehavior<TRequest, TResponse>(ILoggingService loggingService)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
        where TResponse : Result
    {
        private readonly ILoggingService _loggingService = loggingService;
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;

            _loggingService.LogInformation("Started to handle {RequestName}", requestName);

            TResponse result = await next();

            if (result.IsSuccess)
            {
                _loggingService.LogInformation("{RequestName} handled successfully", requestName);
            }
            else
            {
                _loggingService.LogError("{RequestName} failed with error: {Error}", requestName, result.Error);
            }

            return result;
        }
    }
}
