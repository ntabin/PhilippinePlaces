namespace PhilippinePlaces.Providers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using PhilippinePlaces.Entities;

    public class PlacesProvider : IPlacesProvider
    {
        private readonly IEnumerable<RegionEntity> regions;
        private readonly IEnumerable<ProvinceEntity> provinces;
        private readonly IEnumerable<CityEntity> cities;
        private readonly IEnumerable<BarangayEntity> barangays;

        public PlacesProvider()
        {
            this.regions = this.GetSources<RegionEntity>("PhilippinePlaces.Sources.refregion.json");
            this.provinces = this.GetSources<ProvinceEntity>("PhilippinePlaces.Sources.refprovince.json");
            this.cities = this.GetSources<CityEntity>("PhilippinePlaces.Sources.refcitymun.json");
            this.barangays = this.GetSources<BarangayEntity>("PhilippinePlaces.Sources.refbrgy.json");
        }

       

        private IEnumerable<T> GetSources<T>(string embeddedResource)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(embeddedResource))
            using (var reader = new StreamReader(stream))
            {

                string result = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
            }
        }

        public IEnumerable<RegionEntity> GetRegions()
        {
            return this.regions;
        }

        public IEnumerable<ProvinceEntity> GetProvinces()
        {
            return this.provinces;
        }

        public IEnumerable<CityEntity> GetCities()
        {
            return this.cities;
        }

        public IEnumerable<BarangayEntity> GetBarangays()
        {
            return this.barangays;
        }
    }
}
