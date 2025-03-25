using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingCommands : IRequest
    {
        public int Id { get; set; }

        public RemoveOrderingCommands(int id)
        {
            Id = id;
        }
    }
}
