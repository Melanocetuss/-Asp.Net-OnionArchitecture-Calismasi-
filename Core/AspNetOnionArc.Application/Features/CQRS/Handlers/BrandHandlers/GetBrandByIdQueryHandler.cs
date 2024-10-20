using AspNetOnionArc.Application.Features.CQRS.Queries.BrandQueries;
using AspNetOnionArc.Application.Features.CQRS.Results.BrandResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandQueryByIdResult> Handle(GetBrandByIdQuery query) 
        {
            var values = await _repository.GetByIdAsycn(query.Id);          
            return new GetBrandQueryByIdResult
            {
                BrandID = values.BrandID,
                Name = values.Name
            };
        }
    }
}