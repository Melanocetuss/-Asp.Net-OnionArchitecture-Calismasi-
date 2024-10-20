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
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        
        public async Task Handle(CreateBannerCommand command) 
        {
            await _repository.CreateAsycn(new Banner
            {
                Title = command.Title,
                Descripton = command.Descripton,
                VideoDescription = command.VideoDescription,
                VideoUrl = command.VideoUrl
            });
        }
    }
}
