namespace PhilippinePlaces.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using CsvHelper;
    using PhilippinePlaces.Entities;
    using PhilippinePlaces.Models;

    public class PlacesProvider : IPlacesProvider
    {
        public PlacesProvider()
        {
            this.GetRegionEntitiesAsync().Wait();
        }

        public async Task GetRegionEntitiesAsync()
        {
            var regions = this.GetRegionsFromSource();
            var provinces = this.GetProvincesFromSource();
            var cities = this.GetCitieFromSource();
            var barangays = await Task.FromResult<IEnumerable<BarangayCsvModel>>(this.GetBarangaysFromSource());

            var a = from r in regions
                    join p in provinces on r.Code equals p.RegionCode
                    join c in cities on new { Region = r.Code, Province = p.Code } equals new { Region = c.RegionCode, Province = c.ProvinceCode }
                    join b in barangays on new { Region = r.Code, Province = p.Code, City = c.Code } equals new { Region = b.RegionCode, Province = b.ProvinceCode, City = b.CityCode }
                    select new PlaceEntity
                    {
                        RegionCode = r.Code,
                        RegionName = r.Name,
                        ProvinceCode = p.Code,
                        ProvinceName = p.Name,
                        CityCode = c.Code,
                        CityName = c.Name,
                        BarangayCode = b.Code,
                        BarangayName = b.Name
                    };
        }

        public IEnumerable<RegionCsvModel> GetRegionsFromSource()
        {
            IEnumerable <RegionCsvModel> regions = Enumerable.Empty<RegionCsvModel>();
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var b = assembly.GetManifestResourceNames();
                var regionResourceName = "PhilippinePlaces.Sources.refregion.csv";

                using (var stream = assembly.GetManifestResourceStream(regionResourceName))
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                   regions = csv.GetRecords<RegionCsvModel>();
                }
            } catch (Exception ex)
            {

            }

            return regions;


        }

        public IEnumerable<ProvinceCsvModel> GetProvincesFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var regionResourceName = "PhilippinePlaces.Sources.refprovince.csv";

            using (var stream = assembly.GetManifestResourceStream(regionResourceName))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<ProvinceCsvModel>();
            }
        }

        public IEnumerable<CityCsvModel> GetCitieFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var regionResourceName = "PhilippinePlaces.Sources.refcitymun.csv";

            using (var stream = assembly.GetManifestResourceStream(regionResourceName))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<CityCsvModel>();
            }
        }

        public IEnumerable<BarangayCsvModel> GetBarangaysFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var regionResourceName = "PhilippinePlaces.Sources.refbrgy.csv";

            using (var stream = assembly.GetManifestResourceStream(regionResourceName))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<BarangayCsvModel>();
            }
        }



        Task<IEnumerable<RegionEntity>> IPlacesProvider.GetRegionEntitiesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
