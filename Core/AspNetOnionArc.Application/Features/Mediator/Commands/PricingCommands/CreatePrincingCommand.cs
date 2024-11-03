using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.Mediator.Commands.PricingCommands
{
    public class CreatePrincingCommand : IRequest
    {
        public string Name { get; set; }
    }
}