using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class RemoveAddressCommands
    {
        public int Id { get; set; }
        public RemoveAddressCommands(int id)
        {
            Id = id;
        }

       
    }
}
