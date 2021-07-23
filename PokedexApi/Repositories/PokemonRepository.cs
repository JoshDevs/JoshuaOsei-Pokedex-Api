namespace PokedexApi.Repositories
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using PokedexApi.Dto;
    using PokedexApi.Helpers;

    /// <summary>
    /// Class to obtain data of Pokemon.
    /// </summary>
    public class PokemonRepository : IPokemonRepository
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly ITranslationRequestBuilder requestBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonRepository"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/>.</param>
        /// <param name="configuration">An instance of <see cref="IConfiguration"/>.</param>
        /// <param name="requestBuilder">An instance of <see cref="ITranslationRequestBuilder"/>.</param>
        public PokemonRepository(HttpClient httpClient, IConfiguration configuration, ITranslationRequestBuilder requestBuilder)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc/>
        public async Task<PokemonSpecies> GetPokemonSpecies(string pokemon)
        {
            string uri = $"{configuration["PokemonConfig:PokeApiUrl"]}pokemon-species/{pokemon}";
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var data = JsonConvert.DeserializeObject<PokemonSpecies>(await response.Content.ReadAsStringAsync());

            return data;
        }

        public async Task<TranslationResponse> GetTranslation(string description, string language)
        {
            string uri = $"{configuration["PokemonConfig:FunTranslationsUrl"]}{language}.json";

            HttpContent request = requestBuilder.BuildRequest(description, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, request);

            TranslationResponse translation = JsonConvert.DeserializeObject<TranslationResponse>(await response.Content.ReadAsStringAsync());

            return translation;
        }
    }
}
