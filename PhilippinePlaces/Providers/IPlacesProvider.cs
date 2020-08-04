namespace PhilippinePlaces.Providers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PhilippinePlaces.Entities;

    public interface IPlacesProvider
    {
        public Task<IEnumerable<RegionEntity>> GetRegionEntitiesAsync();
    }
}
