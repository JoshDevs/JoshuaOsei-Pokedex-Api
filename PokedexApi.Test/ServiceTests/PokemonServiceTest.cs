
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
        private readonly Mock<ITranslationService> mockTranslationService;

        private readonly PokemonService pokemonService;

        private readonly PokemonSpecies pokemonSpecies = new()
        {
            Name = "test",
            Description = new(),
            Habitat = new(),
            IsLegendary = false,
        };

        private readonly Pokemon pokemon = new()
        {
            Name = "test",
            Description = "expected",
            Habitat = "something",
            IsLegendary = false,
        };

        public PokemonServiceTest()
        {
            mockPokemonRepository = new Mock<IPokemonRepository>(MockBehavior.Strict);
            mockPokemonParser = new Mock<IPokemonParser>();
            mockTranslationService = new Mock<ITranslationService>(MockBehavior.Strict);

            pokemonService = new PokemonService(mockPokemonRepository.Object, mockPokemonParser.Object, mockTranslationService.Object);
        }

        [Fact]
        public async Task CallingGetPokemonDataReturnsPokemonObject()
        {
            mockPokemonRepository.Setup(x => x.GetPokemonSpecies("test")).ReturnsAsync(pokemonSpecies);

            mockPokemonParser.Setup(x => x.ParsePokemon(pokemonSpecies)).Returns(pokemon);

            var response = await pokemonService.GetPokemonData("test");

            response.Should().BeOfType<Pokemon>();

            mockPokemonRepository.Verify(a => a.GetPokemonSpecies("test"), Times.Once);
            mockPokemonParser.Verify(a => a.ParsePokemon(pokemonSpecies), Times.Once);
        }

        [Fact]
        public async Task CallingGetTranslatedPokemonDataReturnsPokemonObject()
        {
            mockPokemonRepository.Setup(x => x.GetPokemonSpecies("test")).ReturnsAsync(pokemonSpecies);

            mockPokemonParser.Setup(x => x.ParsePokemon(pokemonSpecies)).Returns(pokemon);

            mockTranslationService.Setup(x => x.GetTranslation(pokemon)).ReturnsAsync("translated");

            var response = await pokemonService.GetTranslatedPokemonData("test");

            response.Should().BeOfType<Pokemon>();

            mockPokemonRepository.Verify(a => a.GetPokemonSpecies("test"), Times.Once);
            mockPokemonParser.Verify(a => a.ParsePokemon(pokemonSpecies), Times.Once);
            mockTranslationService.Verify(a => a.GetTranslation(pokemon), Times.Once);
        }
    }
}
