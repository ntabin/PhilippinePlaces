using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhilippinePlaces.Entities
{
    public class PlaceEntity
    {
        public string RegionCode { get; set; }

        public string RegionName { get; set; }

        public string ProvinceCode { get; set; }

        public string ProvinceName { get; set; }

        public string CityCode { get; set; }

        public string CityName { get; set; }

        public string BarangayCode { get; set; }

        public string BarangayName { get; set; }
    }
}
