namespace PokedexApi.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Pokemon data object.
    /// </summary>
    public class Pokemon
    {
        /// <summary>
        /// Gets or Sets the Name of the Pokemon.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the Description of the Pokemon.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets the Habitat of the Pokemon.
        /// </summary>
        [JsonProperty("habitat")]
        public string Habitat { get; set; }

        /// <summary>
        /// Gets or sets the flag to determine if a Pokemin is Legendary.
        /// </summary>
        [JsonProperty("isLegendary")]
        public bool IsLegendary { get; set; }
    }
}
