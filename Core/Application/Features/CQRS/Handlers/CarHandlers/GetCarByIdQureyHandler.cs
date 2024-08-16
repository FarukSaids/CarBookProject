using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQureyHandler
    {

        private readonly IRepository<Car> _repoistory;

        public GetCarByIdQureyHandler(IRepository<Car> repoistory)
        {
            _repoistory = repoistory;
        }


        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repoistory.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BrandID =values.BrandID,
                BigImageUrl = values.BigImageUrl,
                CarID = values.CarID,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seats = values.Seats,
                Transmission = values.Transmission   

            };

        }
        


        


    }
}
