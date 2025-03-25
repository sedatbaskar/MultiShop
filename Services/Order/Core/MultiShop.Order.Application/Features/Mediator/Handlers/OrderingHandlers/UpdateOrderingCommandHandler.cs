using MediatR;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommands>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommands request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderingId);
            values.UserId = request.UserId;
            values.OrderDate = request.OrderDate;
            values.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(values);

        }
    }
}
