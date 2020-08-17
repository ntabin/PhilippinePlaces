namespace PhilippinePlaces.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using PhilippinePlaces.Entities;

    public static class PlaceEntityExtensions
    {
        public static IEnumerable<PlaceEntity> AsPlaceEntity<T>(this IEnumerable<T> entities) where T: Place
        {
            return from c in entities
                   select new PlaceEntity
                   {
                       Code = c.Code,
                       Name = c.Name
                   };
        }
    }
}
