using AspNetOnionArc.Application.Features.Mediator.Commands.PricingCommands;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePrincingCommand>
    {
        private readonly IRepository<Pricing> _repository;
        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePrincingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsycn(new Pricing 
            {
                Name = request.Name
            });
        }
    }
}