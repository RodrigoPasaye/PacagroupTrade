using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Pacagroup.Trade.Application.UseCases.Commons.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Request Handling: {Name} - Data: {@Request}", typeof(TRequest).Name, JsonSerializer.Serialize(request));
            var response = await next(cancellationToken);
            _logger.LogInformation("Response Handling: {Name} - Data: {@Response}", typeof(TResponse).Name, JsonSerializer.Serialize(response));
            return response;
        }
    }
}
