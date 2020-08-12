namespace PhilippinePlaces.Providers
{
    using System.Collections.Generic;
    using PhilippinePlaces.Entities;

    public interface IPlacesProvider
    {
        public IEnumerable<PlaceEntity> GetPlaces();
    }
}
