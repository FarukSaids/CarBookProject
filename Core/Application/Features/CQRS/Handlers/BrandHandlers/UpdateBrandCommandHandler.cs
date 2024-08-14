﻿using Application.Features.CQRS.Commands.BannerComands;
using Application.Features.CQRS.Commands.BrandCommands;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {

        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BrandID);
            values.Name = command.Name;
            
            await _repository.UpdateAsync(values);

        }


        


    }
}
