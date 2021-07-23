namespace PokedexApi.Dto
{
    using Newtonsoft.Json;

    /// <summary>
    /// The translation request object.
    /// </summary>
    public class TranslationRequest
    {
        /// <summary>
        /// Gets or Sets the translation text.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
