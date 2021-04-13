namespace PhilippinePlaces.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class CityWithBarangaysWebModel : PlaceModel
    {
        public IEnumerable<PlaceModel> Barangays { get; set; }
    }
}
