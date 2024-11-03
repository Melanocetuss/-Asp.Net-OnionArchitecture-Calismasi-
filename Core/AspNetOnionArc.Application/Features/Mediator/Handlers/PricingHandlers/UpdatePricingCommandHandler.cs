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
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePrincingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePrincingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsycn(request.PricingID);
            values.Name = request.Name;
            await _repository.UpdateAsycn(values);
        }
    }
}