using System.Net.Http;

namespace PokedexApi.Helpers
{
    public interface ITranslationRequestBuilder
    {
        HttpContent BuildRequest(string description, string mediaType);
    }
}