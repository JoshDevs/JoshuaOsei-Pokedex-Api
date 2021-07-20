
namespace PokedexApi.Test.ServiceTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Moq;
    using PokedexApi.Dto;
    using PokedexApi.Helpers;
    using PokedexApi.Models;
    using PokedexApi.Repositories;
    using PokedexApi.Services;
    using Xunit;

    public class PokemonServiceTest
    {
        private readonly Mock<IPokemonRepository> mockPokemonRepository;
        private readonly Mock<IPokemonParser> mockPokemonParser;

        private readonly PokemonService pokemonService;

        public PokemonServiceTest()
        {
            this.mockPokemonRepository = new Mock<IPokemonRepository>(MockBehavior.Strict);
            this.mockPokemonParser = new Mock<IPokemonParser>();

            this.pokemonService = new PokemonService(this.mockPokemonRepository.Object, this.mockPokemonParser.Object);
        }

        [Fact]
        public async Task CallingGetPokemonDataReturnPokemonObject()
        {
            PokemonSpecies pokemonSpecies = new()
            {
                Name = "test",
                Description = new(),
                Habitat = new(),
                isLegendary = false,
            };

            Pokemon pokemon = new()
            {
                Name = "test",
                Description = "expected",
                Habitat = "something",
                IsLegendary = false,
            };

            this.mockPokemonRepository.Setup(x => x.GetPokemonSpecies("test")).ReturnsAsync(pokemonSpecies);

            this.mockPokemonParser.Setup(x => x.ParsePokemon(pokemonSpecies)).Returns(pokemon);

            var response = await this.pokemonService.GetPokemonData("test");

            response.Should().BeOfType<Pokemon>();

            this.mockPokemonRepository.Verify(a => a.GetPokemonSpecies("test"), Times.Once);
            this.mockPokemonParser.Verify(a => a.ParsePokemon(pokemonSpecies), Times.Once);
        }
    }
}
