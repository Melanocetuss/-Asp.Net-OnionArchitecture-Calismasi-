using AspNetOnionArc.Application.Features.CQRS.Commands.CarCommands;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command) 
        {
            var values = await _repository.GetByIdAsycn(command.CarID);
            values.BrandID = command.BrandID;
            values.Model = command.Model;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Km = command.Km;
            values.Transmission = command.Transmission;
            values.Seat = command.Seat;
            values.Luggage = command.Luggage;
            values.Fual = command.Fual;
            values.BigImageUrl = command.BigImageUrl;
            await _repository.UpdateAsycn(values);
        }
    }
}
