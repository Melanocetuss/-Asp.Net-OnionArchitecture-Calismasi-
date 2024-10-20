﻿using AspNetOnionArc.Application.Features.CQRS.Commands.BannerCommands;
using AspNetOnionArc.Application.Features.CQRS.Handlers.BannerHandlers;
using AspNetOnionArc.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetOnionArc.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

        public BannersController(GetBannerQueryHandler getBannerQueryHandler,
                                 GetBannerByIdQueryHandler getBannerByIdQueryHandler,
                                 CreateBannerCommandHandler createBannerCommandHandler,
                                 UpdateBannerCommandHandler updateBannerCommandHandler,
                                 RemoveBannerCommandHandler removeBannerCommandHandler)
        {

            _getBannerQueryHandler = getBannerQueryHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var values = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Afiş Bilgisi Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(RemoveBannerCommand command)
        {
            await _removeBannerCommandHandler.Handle(command);
            return Ok("Afiş Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Afiş Bilgisi Güncellendi");
        }
    }
}