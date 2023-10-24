using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Ardalis.Result;
using System.Text.Json;

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

        public async Task<InnlineLocationDto?> GetLocationAsync(int clientId, string fromCreationDate, string toCreationDate, int skip, bool isDeleted, int take)
        {
            using HttpClient client = _httpClientFactory.CreateClient("BookStoreToInnline");

            await AuthorizeRoutine(client);

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "api/location");

            using HttpResponseMessage response = await client.SendAsync(request);
            
            if (response.IsSuccessStatusCode)
            {
                string locationString = await response.Content.ReadAsStringAsync();
                int index = locationString.IndexOf("]");
                if (index >= 0)
                    locationString = locationString.Substring(0, index);

                var locationJson = JsonConvert.SerializeObject(locationString);

                List<InnlineLocationDto> dtoList = DeserializeJson(locationJson);

                return Result<InnlineLocationDto>.Success(dtoList[0]);
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                if (response.IsSuccessStatusCode)
                {
                    string locationString = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<InnlineLocationDto>(locationString);


                    return location;
                }

                return null;
            }

            return null;
        }

        public async Task<string> PostLocationAsync(InnlineLocationDto innlineLocationDto)
        {
            using HttpClient client = _httpClientFactory.CreateClient("BookStoreToInnline");

            var accessKey = _configuration.GetValue<string>("AccessKeys:AuthClientKey");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("AuthClientKey", accessKey);

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/location");
            using HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                JObject jsonObj = JObject.Parse(jsonString);

                return jsonObj["value"].ToString();
            }
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var authorizeKey = await _innlineClientService.GetTokenAsync();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", authorizeKey);

                return await PostLocationAsync(innlineLocationDto);
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
    }
}
