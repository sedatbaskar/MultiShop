using MediatR;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Query.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResults>
    {
        public int Id { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
