using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using NorthWay.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
    public class ValidationExceptionHandler: ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
    {
        var exception = context.Exception as ValidationException;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var error in exception.Errors)
            {
                stringBuilder.AppendLine(string.Format("Propiedad {0}. Error: {1}",error.PropertyName, error.ErrorMessage)) ;
            }

        return SetResult(context, StatusCodes.Status400BadRequest,"Error en los datos de entrada", stringBuilder.ToString());

    }
}
}
