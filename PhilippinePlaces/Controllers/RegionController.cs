using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhilippinePlaces.Providers;

namespace PhilippinePlaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IPlacesProvider placesProvider;

        public RegionController(IPlacesProvider placesProvider)
        {
            this.placesProvider = placesProvider;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public IActionResult GetRegions()
        {
            return this.Ok();
        }
    }
}
