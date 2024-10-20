using AspNetOnionArc.Application.Features.CQRS.Commands.BrandCommands;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command) 
        {
            var values = await _repository.GetByIdAsycn(command.BrandID);
            values.Name = command.Name;
            await _repository.UpdateAsycn(values);
        }
    }
}
