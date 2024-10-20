using AspNetOnionArc.Application.Features.CQRS.Commands.AboutCommands;
using AspNetOnionArc.Application.Features.CQRS.Handlers.AboutHandlers;
using AspNetOnionArc.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetOnionArc.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createCommandHandler,
                                GetAboutByIdQueryHandler getAboutByIdQueryHandler,
                                GetAboutQueryHandler getAboutQueryHandler,
                                UpdateAboutCommandHandler updateAboutCommandHandler,
                                RemoveAboutCommandHandler removeAboutCommandHandler){
            
            _createCommandHandler = createCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AboutList() 
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id) 
        {
            var value = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command) 
        {
            await _createCommandHandler.Handle(command);
            return Ok("Hakkımda Bilgisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(RemoveAboutCommand command) 
        {
            await _removeAboutCommandHandler.Handle(command);
            return Ok("Hakkımda Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command) 
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Hakkimda Bilgisi Güncellendi");
        }
    }
}