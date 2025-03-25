using MediatR;
using MultiShop.Order.Application.Features.Interfaces;
using MultiShop.Order.Application.Features.Mediator.Query.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResults>
    {

        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResults> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResults
            {
                OrderingId = values.OrderingId,
                UserId = values.UserId,
                TotalPrice = values.TotalPrice,
                OrderDate = values.OrderDate
            };
        } 
    }

}
