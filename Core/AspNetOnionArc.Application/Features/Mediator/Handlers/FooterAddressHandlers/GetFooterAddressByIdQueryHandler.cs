using AspNetOnionArc.Application.Features.Mediator.Queries.FooterAddressQueries;
using AspNetOnionArc.Application.Features.Mediator.Results.FooterAddressResults;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;
        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsycn(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressID = value.FooterAddressID,
                Description = value.Description,
                Address = value.Address,
                Phone = value.Phone,
                Email = value.Email             
            };
        }
    }
}