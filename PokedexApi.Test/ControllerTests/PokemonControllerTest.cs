namespace PokedexApi.Test.ControllerTests
{
    using Moq;
    using FluentAssertions;
    using Xunit;
    using PokedexApi.Services;
    using PokedexApi.Controllers;
    using System.Threading.Tasks;
    using PokedexApi.Models;
    using System;

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

            var response = await pokemonController.GetPokemon("test");
            response.Should().BeOfType<Pokemon>();

            mockPokemonService.Verify(a => a.GetPokemonData("test"), Times.Once);
        }

        [Fact]
        public async Task CallingGetPokemonWithInvalidNameThrowsException()
        {
            mockPokemonService.Setup(x => x.GetPokemonData("error")).Throws(new Exception());

            await Assert.ThrowsAsync<Exception>(() => pokemonController.GetPokemon("error"));
        }

        [Fact]
        public async Task CallingGetTranslatedPokemonReturnsPokemonObject()
        {
            mockPokemonService.Setup(x => x.GetTranslatedPokemonData("test")).ReturnsAsync(new Pokemon());

            var response = await pokemonController.GetTranslatedPokemon("test");
            response.Should().BeOfType<Pokemon>();

            mockPokemonService.Verify(a => a.GetTranslatedPokemonData("test"), Times.Once);
        }

        [Fact]
        public async Task CallingGetTranslatedPokemonWithInvalidNameThrowsException()
        {
            mockPokemonService.Setup(x => x.GetTranslatedPokemonData("error")).Throws(new Exception());

            await Assert.ThrowsAsync<Exception>(() => pokemonController.GetTranslatedPokemon("error"));
        }
    }
}
