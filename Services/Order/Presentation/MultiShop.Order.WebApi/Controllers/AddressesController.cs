using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAdressQueryHandler _getAdressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAdressQueryHandler getAdressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAdressQueryHandler = getAdressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }




        [HttpGet]

        public async Task<IActionResult> AddressList()
        {
            var values = await _getAdressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AdressListById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressComand comand)
        {
            await _createAddressCommandHandler.Handle(comand);
            return Ok("Adres bilgisi başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressComand comand)
        {
            await _updateAddressCommandHandler.Handle(comand);
            return Ok("Adres bilgisi başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressComand(id));
            return Ok("Adres bilgisi başarıyla silindi");

        }
    }
}
