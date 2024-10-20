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
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBrandCommand command) 
        {
            var value = await _repository.GetByIdAsycn(command.Id);
            await _repository.RemoveAsycn(value);
        }
    }
}
