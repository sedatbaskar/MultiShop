using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Query.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var result = await _mediator.Send(new GetOrderingQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var result = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommands command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommands(id));
            return Ok("Sipariş başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(int id, UpdateOrderingCommands command)
        {
            command.OrderingId = id;
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi");
        }
    }
}
