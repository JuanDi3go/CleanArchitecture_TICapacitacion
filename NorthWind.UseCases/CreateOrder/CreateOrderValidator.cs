using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderValidator:AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CostumerId).NotEmpty().WithMessage("Debe proporcionar el identificador del cliente");

            RuleFor(c => c.ShipAdress).NotEmpty().WithMessage("Debe proporcionar direccion de envio");

            RuleFor(c => c.ShipCity).NotEmpty().MinimumLength(3).WithMessage("Debe proporcionar una longitud minima de 3 caracteres");
            RuleFor(c => c.ShipCountry).NotEmpty().MinimumLength(3).WithMessage("Debe proporcionar una longitud minima de 3 caracteres");
            RuleFor(c => c.OrderDetails).Must(d => d != null && d.Any()).WithMessage("Deben especificarse los productos de la orden");
        }
    }
}
