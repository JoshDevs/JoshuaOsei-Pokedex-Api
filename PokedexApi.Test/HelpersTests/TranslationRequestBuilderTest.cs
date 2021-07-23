namespace PokedexApi.Test.HelpersTests
{
    using System.Net.Http;
    using FluentAssertions;
    using PokedexApi.Helpers;
    using Xunit;

    public class TranslationRequestBuilderTest
    {
        private readonly TranslationRequestBuilder requestBuilder;

        public TranslationRequestBuilderTest()
        {
            requestBuilder = new TranslationRequestBuilder();
        }

        [Fact]
        public void CallingBuildRequestReturnsRequestBody()
        {
            var res = requestBuilder.BuildRequest("description", "application/json");

            res.Should().BeOfType<StringContent>();
            res.Should().BeAssignableTo<HttpContent>();
        }
    }
}
