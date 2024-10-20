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
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAboutCommand command) 
        {
            await _repository.CreateAsycn(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
            });
        }
    }
}
