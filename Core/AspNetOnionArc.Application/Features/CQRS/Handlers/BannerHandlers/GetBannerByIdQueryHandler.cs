using AspNetOnionArc.Application.Features.CQRS.Queries.BannerQueries;
using AspNetOnionArc.Application.Features.CQRS.Results.BannerResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query) 
        {
            var values = await _repository.GetByIdAsycn(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                Descripton = values.Descripton,
                Title = values.Title,
                VideoDescription = values.VideoDescription,
                VideoUrl = values.VideoUrl
            };
        }
    }
}
