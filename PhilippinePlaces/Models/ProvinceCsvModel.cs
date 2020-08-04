namespace PhilippinePlaces.Models
{

    using CsvHelper.Configuration.Attributes;

    public class ProvinceCsvModel
    {
        [NameAttribute("id")]
        public int Id { get; set; }

        [NameAttribute("psgcCode")]
        public string PsgcCode { get; set; }

        [NameAttribute("provDesc")]
        public string Name { get; set; }

        [NameAttribute("provCode")]
        public string Code { get; set; }

        [NameAttribute("regCode")]
        public string RegionCode { get; set; }
    }
}
