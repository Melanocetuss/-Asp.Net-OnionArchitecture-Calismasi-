using AspNetOnionArc.Application.Features.CQRS.Commands.BannerCommands;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command) 
        {
            var values = await _repository.GetByIdAsycn(command.BannerID);
            values.Descripton = command.Descripton;
            values.Title = command.Title;
            values.VideoDescription = command.VideoDescription;
            values.VideoUrl = command.VideoUrl;
            await _repository.UpdateAsycn(values);
        }
    }
}
