using AspNetOnionArc.Application.Features.CQRS.Commands.AboutCommands;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAboutCommand command) 
        {
            var value = await _repository.GetByIdAsycn(command.Id);
            await _repository.RemoveAsycn(value);
        }
    }
}
