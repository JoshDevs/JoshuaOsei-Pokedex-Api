namespace PokedexApi.Test.ServiceTests
{
    using Xunit;
    using Moq;
    using FluentAssertions;
    using PokedexApi.Repositories;
    using PokedexApi.Services;
    using System.Threading.Tasks;
    using PokedexApi.Dto;
    using PokedexApi.Models;

    public class TranslationServiceTest
    {
        private readonly Mock<IPokemonRepository> mockPokemonRepository;

        private readonly TranslationService translationService;

        private readonly Pokemon legendary = new()
        {
            Name = "legend",
            Description = "a legend",
            Habitat = "legend land",
            IsLegendary = true,
        };

        private readonly Pokemon cave = new()
        {
            Name = "caveman",
            Description = "a cave dweller",
            Habitat = "cave",
            IsLegendary = false,
        };

        private readonly Pokemon other = new()
        {
            Name = "other",
            Description = "another",
            Habitat = "other",
            IsLegendary = false,
        };

        private readonly TranslationResponse expectedResponse = new ()
        {
            Status = new TranslationStatusResponse()
            {
                Total = 1,
            },
            Contents = new TranslationContentsResponse()
            {
                Translated = "translated",
            },
        };

        public TranslationServiceTest()
        {
            mockPokemonRepository = new Mock<IPokemonRepository>(MockBehavior.Strict);

            translationService = new TranslationService(mockPokemonRepository.Object);
        }

        [Fact]
        public async Task CallingGetTransationWithLegendaryPokemonReturnsString()
        {
            mockPokemonRepository.Setup(x => x.GetTranslation(legendary.Description, "yoda")).ReturnsAsync(expectedResponse);

            var response = await translationService.GetTranslation(legendary);
            response.Should().BeOfType<string>();

            mockPokemonRepository.Verify(a => a.GetTranslation(legendary.Description, "yoda"), Times.Once);
        }

        [Fact]
        public async Task CallingGetTransationWithCavePokemonReturnsString()
        {
            mockPokemonRepository.Setup(x => x.GetTranslation(cave.Description, "yoda")).ReturnsAsync(expectedResponse);

            var response = await translationService.GetTranslation(cave);
            response.Should().BeOfType<string>();

            mockPokemonRepository.Verify(a => a.GetTranslation(cave.Description, "yoda"), Times.Once);
        }

        [Fact]
        public async Task CallingGetTransationWithPokemonReturnsString()
        {
            mockPokemonRepository.Setup(x => x.GetTranslation(other.Description, "shakespeare")).ReturnsAsync(expectedResponse);

            var response = await translationService.GetTranslation(other);
            response.Should().BeOfType<string>();

            mockPokemonRepository.Verify(a => a.GetTranslation(other.Description, "shakespeare"), Times.Once);
        }
    }
}
