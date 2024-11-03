using AspNetOnionArc.Application.Features.Mediator.Commands.FooterAddressCommands;
using AspNetOnionArc.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetOnionArc.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList() 
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id) 
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command) 
        {
            await _mediator.Send(command);
            return Ok("Footer Address Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(int id) 
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Footer Address Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Address Başarıyla Güncellendi");
        }
    }
}