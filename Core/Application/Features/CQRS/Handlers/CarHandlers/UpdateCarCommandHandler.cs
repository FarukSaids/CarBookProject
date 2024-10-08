﻿using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Commands.CarCommands;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {

        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BrandID);
             values.Transmission = command.Transmission;
            values.BigImageUrl = command.BigImageUrl;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Fuel=command.Fuel;
            values.Km=command.Km;
            values.Luggage = command.Luggage;
            values.Seats=command.Seats;
            values.Model=command.Model;
            values.BrandID = command.BrandID;

            await _repository.UpdateAsync(values);

        }
    }
}
