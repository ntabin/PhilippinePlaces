namespace PhilippinePlaces.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using PhilippinePlaces.Entities;
    using PhilippinePlaces.Models;

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

        public static PlaceModel AsModel<T>(this T entity) where T : Place
        {
            return new PlaceModel
            {
                Code = entity.Code,
                Name = entity.Name
            };
        }


        public static IEnumerable<PlaceModel> AsModel<T>(this IEnumerable<T> entities) where T : Place
        {
            return from c in entities
                   select c.AsModel();
                   
        }
    }
}
