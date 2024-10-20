using AspNetOnionArc.Application.Features.CQRS.Queries.CarQueries;
using AspNetOnionArc.Application.Features.CQRS.Results.CarResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdResult> Handle(GetCarByIdQuery query) 
        {
            var values = await _repository.GetByIdAsycn(query.Id);
            return new GetCarByIdResult
            {
                CarID = values.CarID,
                BrandID = values.BrandID,
                Model = values.Model,
                CoverImageUrl = values.CoverImageUrl,
                Km = values.Km,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Luggage = values.Luggage,
                Fual = values.Fual,
                BigImageUrl = values.BigImageUrl
            };
        }
    }
}