using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
   public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressComand comand)
        {
            var values = await _repository.GetByIdAsync(comand.AddressId);
            values.Detail = comand.Detail;
            values.District = comand.District;
            values.City = comand.City;
            values.AddressId = comand.AddressId;
            values.UserId = comand.UserId;
            await _repository.UpdateAsync(values);
            
        }
    }
}
