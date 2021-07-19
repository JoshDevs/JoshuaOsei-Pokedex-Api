namespace PokedexApi.Dto
{
    using Newtonsoft.Json;

    /// <summary>
    /// Pokemon species habitat object.
    /// </summary>
    public class Habitat
    {
        /// <summary>
        /// Gets or Sets name of Pokemon habitat.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
