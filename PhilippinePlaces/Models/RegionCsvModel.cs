namespace PhilippinePlaces.Models
{
    using CsvHelper.Configuration.Attributes;

    public class RegionCsvModel
    {
        [NameAttribute("id")]
        public int Id { get; set; }

        [NameAttribute("psgcCode")]
        public string PsgcCode { get; set; }

        [NameAttribute("regDesc")]
        public string Name { get; set; }

        [NameAttribute("regCode")]
        public string Code { get; set; }
    }
}
