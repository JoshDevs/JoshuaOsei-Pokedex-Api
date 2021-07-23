namespace PokedexApi.Test.HelpersTests
{
    using PokedexApi.Dto;
    using PokedexApi.Helpers;
    using PokedexApi.Models;
    using FluentAssertions;
    using Xunit;

    public class PokemonParserTest
    {
        private readonly PokemonParser pokemonParser;

        private readonly PokemonSpecies pokemonSpecies = new()
        {
            Name = "Test",
            Description = new()
            {
                new Description()
                {
                    DescriptionLanguage = new()
                    {
                        Language = "en",
                    },
                    DescriptionText = "description",
                },
                new Description()
                {
                    DescriptionLanguage = new()
                    {
                        Language = "ro",
                    },
                    DescriptionText = "description Romanian",
                },
            },
            Habitat = new()
            {
                Name = "somewhere",
            },
            IsLegendary = false
        };

        public PokemonParserTest()
        {
            pokemonParser = new PokemonParser();
        }

        [Fact]
        public void CallingParsePokemonReturnsPokemonObject()
        {
            var expected = new Pokemon()
            {
                Name = "Test",
                Description = "description",
                Habitat = "somewhere",
                IsLegendary = false
            };
            var res = pokemonParser.ParsePokemon(pokemonSpecies);

            res.Should().BeOfType<Pokemon>();
            res.Should().BeEquivalentTo(expected);
        }
    }
}
