namespace PokedexApi.Dto
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Pokemon species response object.
    /// </summary>
    public class PokemonSpecies
    {
        /// <summary>
        /// Gets or Sets name of Pokemon.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets a collection of description.
        /// </summary>
        [JsonProperty(PropertyName = "flavor_text_entries")]
        public List<Description> Description { get; set; }

        /// <summary>
        /// Gets or Sets the habitat of the Pokemon.
        /// </summary>
        [JsonProperty(PropertyName = "habitat")]
        public Habitat Habitat { get; set; }

        /// <summary>
        /// Gets or Sets flag to determine if Pokemon is legendary.
        /// </summary>
        [JsonProperty(PropertyName = "is_legendary")]
        public bool isLegendary { get; set; }
    }
}
