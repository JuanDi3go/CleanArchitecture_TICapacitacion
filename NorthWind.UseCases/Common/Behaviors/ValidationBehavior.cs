using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.Common.Behaviors
{
    public class ValidationBehavior<Trequest, TResponse> : IPipelineBehavior<Trequest, TResponse> where Trequest : IRequest<TResponse>
    {
        readonly IEnumerable<IValidator<Trequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<Trequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(Trequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var Failures = _validators.Select(v => v.Validate(request)).SelectMany(v => v.Errors).Where(f => f != null).ToList();
            if (Failures.Any())
            {
                throw new ValidationException(Failures);

            }
            return next();
        }
    }
}
