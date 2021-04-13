namespace PhilippinePlaces.Tests.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegionsControllerTest
    {
        private  WebApplicationFactory<Startup> factory;

        [TestInitialize]
        public void Setup()
        {
            factory = new WebApplicationFactory<Startup>();
        }

        [TestCleanup]
        public void Teardown()
        {
            factory.Dispose();
        }

        [TestMethod]
        public async Task ShouldReturnSuccessResponse()
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync("api/regions?region");
            var result = await response.Content.ReadAsAsync<string>();
        }
    }
}