namespace PokedexApi.Test.ControllerTests
{
    using Moq;
    using FluentAssertions;
    using Xunit;
    using PokedexApi.Services;
    using PokedexApi.Controllers;
    using System.Threading.Tasks;
    using PokedexApi.Models;

    public class PokemonControllerTest
    {
        private readonly Mock<IPokemonService> mockPokemonService;

        private readonly PokemonController pokemonController;

        public PokemonControllerTest()
        {
            mockPokemonService = new Mock<IPokemonService>(MockBehavior.Strict);

            pokemonController = new PokemonController(this.mockPokemonService.Object);
        }

        [Fact]
        public async Task CallingGetPokemonReturnsPokemonObject()
        {
            mockPokemonService.Setup(x => x.GetPokemonData("test")).ReturnsAsync(new Pokemon());

            var response = await this.pokemonController.GetPokemon("test");
            response.Should().BeOfType<Pokemon>();

            mockPokemonService.Verify(a => a.GetPokemonData("test"), Times.Once);
        }

        [Fact]
        public async Task CallingGetTranslatedPokemonReturnsPokemonObject()
        {
            mockPokemonService.Setup(x => x.GetTranslatedPokemonData("test")).ReturnsAsync(new Pokemon());

            var response = await this.pokemonController.GetTranslatedPokemon("test");
            response.Should().BeOfType<Pokemon>();

            mockPokemonService.Verify(a => a.GetTranslatedPokemonData("test"), Times.Once);
        }
    }
}
