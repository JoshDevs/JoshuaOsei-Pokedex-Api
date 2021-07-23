namespace PokedexApi.Dto
{
    using Newtonsoft.Json;

    /// <summary>
    /// Flavor text object.
    /// </summary>
    public class Description
    {
        /// <summary>
        /// Gets or Sets the description text of the Pokemon.
        /// </summary>
        [JsonProperty(PropertyName = "flavor_text")]
        public string DescriptionText { get; set; }

        /// <summary>
        /// Gets or Sets the language of the description of the Pokemon.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public DescriptionLanguage DescriptionLanguage { get; set; }
    }
}
