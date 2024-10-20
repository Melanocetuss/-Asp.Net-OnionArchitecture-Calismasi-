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
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsycn();
            return values.Select(x=> new GetBrandQueryResult 
            {
                BrandID = x.BrandID,
                Name = x.Name,
            }).ToList();
        }
    }
}