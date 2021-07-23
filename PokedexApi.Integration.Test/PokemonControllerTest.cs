namespace PokedexApi.Integration.Test
{
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Newtonsoft.Json;
    using PokedexApi.Models;
    using Xunit;

    public class PokemonControllerTest : IntegrationTest
    {
        private readonly string pokemonEndPoint = "/api/Pokemon/";
        private readonly string translationEndPoint = "/api/translated/";

        public PokemonControllerTest()
        {
        }

        [Theory]
        [InlineData("ditto")]
        [InlineData("meWTwo")]
        public async Task CallingGetPokemonReturnsDetailsOfAPokemon(string name)
        {
            string uri = $"{pokemonEndPoint}/{name}";

            var response = await httpClient.GetAsync(uri);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var pokemon = JsonConvert.DeserializeObject<Pokemon>(await response.Content.ReadAsStringAsync());
            pokemon.Name.Should().BeEquivalentTo(name.ToLower());
            pokemon.Description.Should().NotBeNullOrEmpty();
            pokemon.Habitat.Length.Should().NotBe(0);
        }
    }
}
