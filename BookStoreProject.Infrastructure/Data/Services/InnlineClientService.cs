using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class InnlineClientService : IInnlineClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public InnlineClientService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<string> GetTokenAsync()
        {
            using HttpClient client = _httpClientFactory.CreateClient("BookStoreToInnline");
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "api/client/get-token");

            var accessKey = _configuration.GetValue<string>("AccessKeys:AuthClientKey");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("AuthClientKey", accessKey);

            using HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                JObject jsonObj = JObject.Parse(jsonString);

                return jsonObj["value"].ToString();
            }
            else
            {
                return $"Status code: {response.StatusCode}";
            }
        }
    }
}
