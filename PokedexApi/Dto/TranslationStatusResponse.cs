namespace PokedexApi.Dto
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Translation Status response object.
    /// </summary>
    public class TranslationStatusResponse
    {
        /// <summary>
        /// Gets the transaltion status total.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
