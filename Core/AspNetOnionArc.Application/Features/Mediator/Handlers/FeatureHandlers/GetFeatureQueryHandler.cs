using AspNetOnionArc.Application.Features.Mediator.Queries.FeatureQueries;
using AspNetOnionArc.Application.Features.Mediator.Results.FeatureResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;
        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, 
                                                        CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsycn();
            return values.Select(x=> new GetFeatureQueryResult 
            {
                FeatureID = x.FeatureID,
                Name = x.Name
            }).ToList();
        }
    }
}