﻿using AspNetOnionArc.Application.Features.CQRS.Results.CarResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        
        public async Task<List<GetCarQueryResult>> Handle() 
        {
            var values = await _repository.GetAllAsycn();
            return values.Select(x => new GetCarQueryResult 
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
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