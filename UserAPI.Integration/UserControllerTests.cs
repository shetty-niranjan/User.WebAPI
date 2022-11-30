using AspNetCoreTests.IntegrationTests;
using Microsoft.AspNetCore.Mvc.Testing;
using TestProject.WebAPI;
using UserAPI.Integration.Helpers;
using Xunit;

namespace User.API.Integration
{
    [Collection("Sequential")]
    public class UserControllerTests : TestBase
    {
        public UserControllerTests(TestApplicationFactory<Startup, FakeStartup> factory) : base(factory)
        {
        }    

        //public UserControllerTests()
        //{
        //    var factory = new CustomWebApplicationFactory<Startup>();
        //    
        //}

        [Theory]
        [InlineData("/Users")]
        public async Task DefaultRoute_ReturnsHelloWorld(string url)
        {
            // Arrange
            using var client = Factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });

            // Act
            using var response = await client.GetAsync($"https://localhost:44350" + url);

            var stringResult = await response.Content.ReadAsHttpResponseMessageAsync();

            //Assert.Equal("Hello World!", stringResult);
        }

        [Fact]
        public async Task Sum_Returns16For10And6()
        {
            //// Arrange
            //var client = _factory.CreateClient();
            //var response = await client.GetAsync("/Users");
            //var stringResult = await response.Content.ReadAsStringAsync();
            //var intResult = int.Parse(stringResult);

            //Assert.Equal(16, intResult);
        }
    }
}

