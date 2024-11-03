using AspNetOnionArc.Application.Features.Mediator.Queries.PricingQueries;
using AspNetOnionArc.Application.Features.Mediator.Results.PricingResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;
        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsycn();
            return values.Select(x=> new GetPricingQueryResult 
            {
                PricingID = x.PricingID,
                Name = x.Name
            }).ToList();
        }
    }
}