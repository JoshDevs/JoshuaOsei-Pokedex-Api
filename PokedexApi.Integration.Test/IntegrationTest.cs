namespace PokedexApi.Integration.Test
{
    using System.Net.Http;
    using Microsoft.AspNetCore.Mvc.Testing;

    /// <summary>
    /// Base Integration Test Class
    /// </summary>
    public class IntegrationTest
    {
        protected readonly HttpClient httpClient;

        protected IntegrationTest()
        {
            var factory = new WebApplicationFactory<Startup>();
            httpClient = factory.CreateClient();
        }
    }
}