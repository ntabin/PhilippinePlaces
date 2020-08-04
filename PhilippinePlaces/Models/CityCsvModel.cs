namespace PhilippinePlaces.Models
{
    using CsvHelper.Configuration.Attributes;

    public class CityCsvModel
    {
        [NameAttribute("id")]
        public int Id { get; set; }

        [NameAttribute("psgcCode")]
        public string PsgcCode { get; set; }

        [NameAttribute("citymunDesc")]
        public string Name { get; set; }

        [NameAttribute("citymunCode")]
        public string Code { get; set; }

        [NameAttribute("regCode")]
        public string RegionCode { get; set; }

        [NameAttribute("provCode")]
        public string ProvinceCode { get; set; }
    }
}
