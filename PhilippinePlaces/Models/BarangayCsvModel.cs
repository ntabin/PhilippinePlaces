using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace PhilippinePlaces.Models
{
    public class BarangayCsvModel
    {
        [NameAttribute("id")]
        public int Id { get; set; }

        [NameAttribute("brgyDesc")]
        public string Name { get; set; }

        [NameAttribute("brgyCode")]
        public string Code { get; set; }

        [NameAttribute("regCode")]
        public string RegionCode { get; set; }

        [NameAttribute("provCode")]
        public string ProvinceCode { get; set; }

        [NameAttribute("citymunCode")]
        public string CityCode { get; set; }
    }
}
