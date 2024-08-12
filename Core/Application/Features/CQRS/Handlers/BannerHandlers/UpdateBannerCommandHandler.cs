﻿using Application.Features.CQRS.Commands.BannerComands;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandlers
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
            var result = _repository.UpdateAsync(new Banner { 
                Title = command.Title, 
                BannerID = command.BannerID,
                Description = command.Description,
                VideoDescription = command.VideoDescription,
                VideoUrl= command.VideoUrl, 



            });


        }






    }
}
