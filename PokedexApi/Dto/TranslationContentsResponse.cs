namespace PokedexApi.Dto
{
    using Newtonsoft.Json;

    /// <summary>
    /// The translation contents response object.
    /// </summary>
    public class TranslationContentsResponse
    {
        /// <summary>
        /// Gets translated text.
        /// </summary>
        [JsonProperty("translated")]
        public string Translated { get; set; }
    }
}
