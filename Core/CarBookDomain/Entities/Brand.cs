﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookDomain.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string Name { get; set; }    
        public List<Car> Cars { get; set; }
        //birden fazla arabayı kapsayacak marka isimleri 
    }
}
