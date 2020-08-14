namespace PhilippinePlaces.Providers
{
    using System.Collections.Generic;
    using PhilippinePlaces.Entities;

    public interface IPlacesProvider
    {
        public IEnumerable<RegionEntity> GetRegions();

        public IEnumerable<ProvinceEntity> GetProvinces();

        public IEnumerable<CityEntity> GetCities();

        public IEnumerable<BarangayEntity> GetBarangays();
    }
}
