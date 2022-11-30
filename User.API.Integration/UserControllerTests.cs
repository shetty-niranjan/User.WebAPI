using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using TestProject.WebAPI;

namespace User.API.Integration
{
    public class UserControllerTests
    {
        private HttpClient _httpClient;

        public UserControllerTests()
        {
            var factory = new CustomWebApplicationFactory<Startup>().WithWebHostBuilder(builder => { });
            _httpClient = factory.CreateDefaultClient();
        }

        [Test]
        public async Task DefaultRoute_ReturnsHelloWorld()
        {
            var response = await _httpClient.GetAsync("");
            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.AreEqual("Hello World!", stringResult);
        }

        [Test]
        public async Task Sum_Returns16For10And6()
        {
            var response = await _httpClient.GetAsync("/sum?n1=10&n2=6");
            var stringResult = await response.Content.ReadAsStringAsync();
            var intResult = int.Parse(stringResult);

            Assert.AreEqual(16, intResult);
        }
    }
}

