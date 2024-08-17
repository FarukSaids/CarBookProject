using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        public List<Car> GetCarListWithBrand();
    }
}
