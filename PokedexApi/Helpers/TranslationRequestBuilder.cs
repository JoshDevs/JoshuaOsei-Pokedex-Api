namespace PokedexApi.Helpers
{
    using System.Net.Http;
    using System.Text;
    using Newtonsoft.Json;
    using PokedexApi.Dto;

    /// <summary>
    /// The Helper class to build requests.
    /// </summary>
    public class TranslationRequestBuilder : ITranslationRequestBuilder
    {
        /// <inheritdoc/>
        public HttpContent BuildRequest(string description, string mediaType)
        {
            TranslationRequest translationRequest = new()
            {
                Text = description,
            };

            var content = new StringContent(JsonConvert.SerializeObject(translationRequest), Encoding.UTF8, mediaType);

            return content;
        }
    }
}
