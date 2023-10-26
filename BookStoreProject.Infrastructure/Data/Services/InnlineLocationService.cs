using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ardalis.Result;
using System.Text.Json;
using System.Text;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class InnlineLocationService : IInnlineLocationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IInnlineClientService _innlineClientService;

        public InnlineLocationService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IInnlineClientService innlineClientService)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _innlineClientService = innlineClientService;
        }

        public async Task<List<InnlineLocationDto>?> GetLocationAsync(int clientId, string fromCreationDate, string toCreationDate, int skip, bool isDeleted, int take)
        {
            using HttpClient client = _httpClientFactory.CreateClient("BookStoreToInnline");

            await AuthorizeRoutine(client);

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "api/location");
            using HttpResponseMessage response = await client.SendAsync(request);
            
            
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                var locationString = await response.Content.ReadAsStringAsync();
                return await OneRootObjectsJsonDeserializer(locationString);
            }

            return null;
        }

        public async Task<string> PostLocationAsync(InnlineLocationDto innlineLocationDto)
        {
            using HttpClient client = _httpClientFactory.CreateClient("BookStoreToInnline");

            await AuthorizeRoutine(client);

            var json = System.Text.Json.JsonSerializer.Serialize(innlineLocationDto);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await client.PostAsync("api/location", content);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                JObject jsonObj = JObject.Parse(jsonString);

                return jsonObj.ToString();
            }

            return null;
        }

        public async Task<HttpClient> AuthorizeRoutine(HttpClient client)
        {
            var accessKey = _configuration.GetValue<string>("AccessKeys:AuthClientKey");
            client.DefaultRequestHeaders.Add("AuthClientKey", accessKey);

            var authorizeKey = await _innlineClientService.GetTokenAsync();
            client.DefaultRequestHeaders.Add("Basic", authorizeKey);

            return client;
        }
        public async Task<List<InnlineLocationDto>> OneRootObjectsJsonDeserializer(string objJsonString)
        {
            int indexEnd = objJsonString.IndexOf("]");

            objJsonString = objJsonString.Substring(0, indexEnd + 1);

            objJsonString = objJsonString + "}";

            try
            {
                Value jsonObject = JsonConvert.DeserializeObject<Value>(objJsonString);

                return Result<List<InnlineLocationDto>>.Success(jsonObject.DtoList);
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine($"JSON parsing error: {ex.Message}");
                return null;
            }
        }
    }
    public class Value
    {
        [JsonProperty(PropertyName = "value")]
        public List<InnlineLocationDto> DtoList { get; set; }
    }
}
