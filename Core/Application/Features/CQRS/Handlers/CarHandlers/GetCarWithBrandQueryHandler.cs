using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Application.Interfaces.CarInterfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {

      private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public  List<GetCarWithBrandQueryResult> Handle()
        {

            var values =  _carRepository.GetCarListWithBrand();
            
       
            return values.Select(x => new GetCarWithBrandQueryResult  //values.Select(...): Her bir value öğesi için GetCarQueryResult nesnesi oluşturur.
            {
                BrandName=x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seats = x.Seats,
                Transmission = x.Transmission,
               
                
            }).ToList();
        }

    }
}
