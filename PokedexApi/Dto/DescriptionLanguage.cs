namespace PokedexApi.Dto
{
    using Newtonsoft.Json;

    /// <summary>
    /// Flavor text language object.
    /// </summary>
    public class DescriptionLanguage
    {
        /// <summary>
        /// Gets or Sets the language of the Pokemon description.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Language { get; set; }
    }
}
