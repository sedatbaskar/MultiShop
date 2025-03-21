using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommands
    {
        public int Id { get; set; }

        public RemoveOrderDetailCommands(int id)
        {
            Id = id;
        }
    }
}
