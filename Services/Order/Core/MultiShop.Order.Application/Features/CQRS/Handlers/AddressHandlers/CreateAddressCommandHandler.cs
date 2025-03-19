using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{


    //Read Write---- Result

    //Read Parametre ---- Queries

    //Parametreler (Ekleme Silme Güncelleme) Commands

    //Crud işlemleri Handlers 

    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommands createAddressCommands)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommands.City,
                Detail = createAddressCommands.Detail,
                UserId = createAddressCommands.UserId,
                District = createAddressCommands.District

            });

        }
    }
}
