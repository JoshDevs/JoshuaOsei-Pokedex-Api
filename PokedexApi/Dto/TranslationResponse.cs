namespace PokedexApi.Dto
{
    using Newtonsoft.Json;

    /// <summary>
    /// Translation Response Object.
    /// </summary>
    public class TranslationResponse
    {
        /// <summary>
        /// Gets translation success status.
        /// </summary>
        [JsonProperty("success")]
        public TranslationStatusResponse Status { get; set; }

        /// <summary>
        /// Gets translation contents.
        /// </summary>
        [JsonProperty("contents")]
        public TranslationContentsResponse Contents { get; set; }
    }
}
