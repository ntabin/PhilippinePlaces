namespace PhilippinePlaces.Providers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using PhilippinePlaces.Entities;
    using PhilippinePlaces.Models;

    public class PlacesProvider : IPlacesProvider
    {
        private readonly IEnumerable<PlaceEntity> places;

        public PlacesProvider()
        {
            this.places = this.PopulatePlaceEntity();
        }

        public IEnumerable<PlaceEntity> GetPlaces()
        {
            return this.places;
        }

        private IEnumerable<PlaceEntity> PopulatePlaceEntity()
        {
            var regions = this.GetRegionsFromSource();
            var provinces = this.GetProvincesFromSource();
            var cities = this.GetCitieFromSource();
            var barangays = this.GetBarangaysFromSource();

            var places = from r in regions
                             join p in provinces on r.Code equals p.RegionCode
                             join c in cities on p.Code equals c.ProvinceCode
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
            return places;
        }

        private IEnumerable<RegionCsvModel> GetRegionsFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("PhilippinePlaces.Sources.refregion.json"))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<RegionCsvModel>>(result);
            }
        }

        private IEnumerable<ProvinceCsvModel> GetProvincesFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("PhilippinePlaces.Sources.refprovince.json"))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<ProvinceCsvModel>>(result);
            }
        }

        private IEnumerable<CityCsvModel> GetCitieFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("PhilippinePlaces.Sources.refcitymun.json"))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<CityCsvModel>>(result);
            }
        }

        private IEnumerable<BarangayCsvModel> GetBarangaysFromSource()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream("PhilippinePlaces.Sources.refbrgy.json"))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<BarangayCsvModel>>(result);
            }
        }
    }
}
