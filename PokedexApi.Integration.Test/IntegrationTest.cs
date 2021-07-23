namespace PokedexApi.Integration.Test
{
    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    /// <summary>
    /// Base Integration Test Class
    /// </summary>
    public class IntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient httpClient;

        protected IntegrationTest(WebApplicationFactory<Startup> factory)
        {
            httpClient = factory.CreateClient();
        }
    }
}