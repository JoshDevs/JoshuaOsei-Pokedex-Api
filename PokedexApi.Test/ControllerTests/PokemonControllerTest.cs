namespace PokedexApi.Test.ControllerTests
{
    using System;
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
            this.mockPokemonService = new Mock<IPokemonService>(MockBehavior.Strict);

            this.pokemonController = new PokemonController(this.mockPokemonService.Object);
        }

        [Fact]
        public async Task CallingGetPokemonReturnPokemObject()
        {
            this.mockPokemonService.Setup(x => x.GetPokemonData("test")).ReturnsAsync(new Pokemon());

            var response = await this.pokemonController.GetPokemon("test");
            response.Should().BeOfType<Pokemon>();

            this.mockPokemonService.Verify(a => a.GetPokemonData("test"), Times.Once);
        }
    }
}
