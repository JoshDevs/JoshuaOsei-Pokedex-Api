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

        public TranslationServiceTest()
        {
            mockPokemonRepository = new Mock<IPokemonRepository>(MockBehavior.Strict);

            translationService = new TranslationService(mockPokemonRepository.Object);
        }

        [Fact]
        public async Task CallingGetTransationWithLegendaryPokemonReturnsString()
        {
            mockPokemonRepository.Setup(x => x.GetTranslation(legendary.Description, "application/json")).ReturnsAsync(new TranslationResponse());

            var response = await translationService.GetTranslation(legendary);
            response.Should().BeOfType<string>();

            mockPokemonRepository.Verify(a => a.GetTranslation(legendary.Description, "application/json"), Times.Once);
        }
    }
}
