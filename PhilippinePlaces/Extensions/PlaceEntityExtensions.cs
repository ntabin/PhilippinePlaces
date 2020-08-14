namespace PhilippinePlaces.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using PhilippinePlaces.Entities;

    public static class PlaceEntityExtensions
    {
        public static IEnumerable<PlaceEntity> AsPlaceEntity(this IEnumerable<RegionEntity> regions, string regionCode = "")
        {
            return from r in regions
                   where r.Code == regionCode || regionCode == string.Empty
                   select new PlaceEntity
                   {
                       Code = r.Code,
                       Name = r.Name
                   };
        }



        public static IEnumerable<PlaceEntity> AsPlaceEntity(this IEnumerable<ProvinceEntity> provinces)
        {
            return from p in provinces
                   select new PlaceEntity()
                   {
                       Code = p.Code,
                       Name = p.Name
                   };
        }

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
