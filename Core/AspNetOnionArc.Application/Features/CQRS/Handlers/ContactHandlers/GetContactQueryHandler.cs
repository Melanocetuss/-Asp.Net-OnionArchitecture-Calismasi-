using AspNetOnionArc.Application.Features.CQRS.Commands.ContactCommands;
using AspNetOnionArc.Application.Features.CQRS.Results.ContactResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle() 
        {
            var values = await _repository.GetAllAsycn();
            return values.Select(x => new GetContactQueryResult 
            {
                ContactID = x.ContactID,
                Name = x.Name,
                Email = x.Email,
                Subject = x.Subject,
                Message = x.Message,
                SendDate = x.SendDate
            }).ToList();
        }
    }
}