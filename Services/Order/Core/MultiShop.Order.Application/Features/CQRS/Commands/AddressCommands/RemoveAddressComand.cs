﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressComand
    {
        public int Id { get; set; }

        public RemoveAddressComand(int id)
        {
            Id = id;
        }
    }
}
