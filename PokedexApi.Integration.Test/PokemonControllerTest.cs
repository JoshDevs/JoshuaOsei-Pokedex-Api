namespace PokedexApi.Integration.Test
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Newtonsoft.Json;
    using PokedexApi.Models;
    using Xunit;

    public class PokemonControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient httpClient;

        public PokemonControllerTest(WebApplicationFactory<Startup> factory)
        {
            httpClient = factory.CreateClient();
        }

        [Theory]
        [InlineData("ditto")]
        [InlineData("meWTwo")]
        public async Task CallingGetPokemonReturnsDetailsOfAPokemon(string name)
        {
            string uri = $"api/Pokemon/{name}";

            var response = await httpClient.GetAsync(uri);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var pokemon = JsonConvert.DeserializeObject<Pokemon>(await response.Content.ReadAsStringAsync());
            pokemon.Name.Should().BeEquivalentTo(name.ToLower());
            pokemon.Description.Should().NotBeNullOrEmpty();
            pokemon.Habitat.Length.Should().NotBe(0);
        }

        [Fact]
        public async Task CallingGetTranslatedPokemonWithLegendaryPokemonReturnsDetailsOfAPokemon()
        {
            string uri = $"api/Pokemon/Lugia";

            var response = await httpClient.GetAsync(uri);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var pokemon = JsonConvert.DeserializeObject<Pokemon>(await response.Content.ReadAsStringAsync());
            pokemon.Name.Should().BeEquivalentTo("lugia");
            pokemon.IsLegendary.Should().BeTrue();
        }

        [Fact]
        public async Task CallingGetTranslatedPokemonWithACavePokemonReturnsDetailsOfAPokemon()
        {
            string uri = $"api/Pokemon/zubaT";

            var response = await httpClient.GetAsync(uri);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var pokemon = JsonConvert.DeserializeObject<Pokemon>(await response.Content.ReadAsStringAsync());
            pokemon.Name.Should().BeEquivalentTo("zubat");
            pokemon.Habitat.Should().BeEquivalentTo("cave");
        }

        [Fact]
        public async Task CallingGetPokemonwithInvalidNameThrowsException()
        {
            string uri = $"api/Pokemon/error";

            var response = await httpClient.GetAsync(uri);
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }
    }
}
