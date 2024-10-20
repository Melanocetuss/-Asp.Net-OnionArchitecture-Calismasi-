using AspNetOnionArc.Application.Features.CQRS.Results.CarResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Application.Interfaces.CarInterfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;
        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetCarWithBrandQueryResult> Handle() 
        {
            var values = _repository.GetCarListWithBrands();
            return values.Select(x =>  new GetCarWithBrandQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Fual = x.Fual,
                BigImageUrl = x.BigImageUrl
            }).ToList();
        }
    }
}
