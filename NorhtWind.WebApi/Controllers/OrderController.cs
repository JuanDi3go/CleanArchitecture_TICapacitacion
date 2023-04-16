using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.UseCases.CreateOrder;

namespace NorhtWind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create-order")]

        public async Task<ActionResult<int>> CreateOrder(CreateOrderInputPort orderParams)
        {
            return await _mediator.Send(orderParams);
        }
    }
}
