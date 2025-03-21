using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        
        public async Task Handle(UpdateOrderDetailCommands command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.OrderingId = command.OrderingId;
            values.ProductAmount = command.ProductAmount;
            values.ProductName = command.ProductName;
            values.ProductId = command.ProductId;
            values.ProductPrice = command.ProductPrice;
            values.ProductTotalPrice = command.ProductTotalPrice;
            await _repository.UpdateAsync(values);
        }
    }
}
