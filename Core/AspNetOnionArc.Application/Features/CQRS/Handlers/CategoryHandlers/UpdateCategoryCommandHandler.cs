﻿using AspNetOnionArc.Application.Features.CQRS.Commands.CategoryCommands;
using AspNetOnionArc.Application.Interfaces;
using AspNetOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetOnionArc.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand command) 
        {
            var values = await _repository.GetByIdAsycn(command.CategoryID);
            values.Name = command.Name;
            await _repository.UpdateAsycn(values);
        }
    }
}