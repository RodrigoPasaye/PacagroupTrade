using FluentValidation;
using MediatR;
using Pacagroup.Trade.Application.UseCases.Commons.Exceptions;

namespace Pacagroup.Trade.Application.UseCases.Commons.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.Where(f => f.Errors.Count != 0).SelectMany(r => r.Errors).ToList();
                if (failures.Count != 0)
                    throw new ValidationExceptionCustom(failures);
            }
            return await next(cancellationToken);
        }
    }
}
