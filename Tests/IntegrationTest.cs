/* using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

//Not completed

namespace Diffing.Tests
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        // public HttpClient Client { get; }
        private readonly WebApplicationFactory<TestStartup> _factory;

        public IntegrationTest(WebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/v1/diff")]
        public async Task GetResult(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299


        }

    }
} */