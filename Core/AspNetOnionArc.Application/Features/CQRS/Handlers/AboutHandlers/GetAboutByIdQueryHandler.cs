using AspNetOnionArc.Application.Features.CQRS.Results.AboutResults;
using AspNetOnionArc.Application.Features.CQRS.Queries.AboutQueries;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;
        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _repository.GetByIdAsycn(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutID = values.AboutID,
                Description = values.Description,
                Title = values.Title,
                ImageUrl = values.ImageUrl
            };
        }
    }
}
