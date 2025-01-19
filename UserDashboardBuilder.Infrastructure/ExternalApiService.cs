using System;
using System.Net.Http;
using Polly;


using System.Threading.Tasks;

namespace UserDashboardBuilder.Infrastructure
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(IHttpClientFactory httpClientFactory)
        {
            
            _httpClient = httpClientFactory.CreateClient("ExternalApi");
        }

        public async Task<string> GetApiDataAsync()
        {
            
            var response = await _httpClient.GetAsync("/endpoint");
            response.EnsureSuccessStatusCode(); 

            return await response.Content.ReadAsStringAsync();
        }
    }
}
