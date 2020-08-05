namespace PhilippinePlaces.Providers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
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
                   // join c in cities on new { Region = r.Code, Province = p.Code } equals new { Region = c.RegionCode, Province = c.ProvinceCode }
                   // join b in barangays on new { Region = r.Code, Province = p.Code, City = c.Code } equals new { Region = b.RegionCode, Province = b.ProvinceCode, City = b.CityCode }
                    select new PlaceEntity
                    {
                        RegionCode = r.Code,
                        RegionName = r.Name,
                        ProvinceCode = p.Code,
                        ProvinceName = p.Name
                       // CityCode = c.Code,
                       // CityName = c.Name,
                       // BarangayCode = b.Code,
                       // BarangayName = b.Name
                    };
        }

        public IEnumerable<RegionCsvModel> GetRegionsFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("PhilippinePlaces.Sources.refregion.json"))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<RegionCsvModel>>(result);
            }
        }

        public IEnumerable<ProvinceCsvModel> GetProvincesFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("PhilippinePlaces.Sources.refprovince.json"))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<ProvinceCsvModel>>(result);
            }
        }

        public IEnumerable<CityCsvModel> GetCitieFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("PhilippinePlaces.Sources.refcitymun.json"))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<CityCsvModel>>(result);
            }
        }

        public IEnumerable<BarangayCsvModel> GetBarangaysFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("PhilippinePlaces.Sources.refbrgy.json"))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<BarangayCsvModel>>(result);
            }
        }



        Task<IEnumerable<RegionEntity>> IPlacesProvider.GetRegionEntitiesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
