using NUnit.Framework;

namespace ImgArena.Api.Tests
{
    //todo integration test of the controller with fake databsem startup, service registration
    //for example https://docs.microsoft.com/pl-pl/dotnet/architecture/microservices/multi-container-microservice-net-applications/test-aspnet-core-services-web-apps
    //public class PrimeWebDefaultRequestShould
    //{
    //    private readonly TestServer _server;
    //    private readonly HttpClient _client;

    //    public PrimeWebDefaultRequestShould()
    //    {
    //        // Arrange
    //        _server = new TestServer(new WebHostBuilder()
    //           .UseStartup<Startup>());
    //        _client = _server.CreateClient();
    //    }

    //    [Fact]
    //    public async Task ReturnHelloWorld()
    //    {
    //        // Act
    //        var response = await _client.GetAsync("/");
    //        response.EnsureSuccessStatusCode();
    //        var responseString = await response.Content.ReadAsStringAsync();
    //        // Assert
    //        Assert.Equal("Hello World!", responseString);
    //    }
    //}
    public class ProductsControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}