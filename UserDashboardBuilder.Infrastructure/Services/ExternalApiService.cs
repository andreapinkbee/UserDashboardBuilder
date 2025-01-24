using System;
using System.Net.Http;
using System.Threading.Tasks;
using UserDashboardBuilder.Core;
using UserDashboardBuilder.Core.Interfaces;
using Polly;


namespace UserDashboardBuilder.Infrastructure.Services
{
    public class ExternalApiService:IExternalApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IApiResponseHandlerService _apiResponseHandlerService;

        public ExternalApiService(
             IHttpClientFactory httpClientFactory,
             IApiResponseHandlerService apiResponseHandlerService)
        {
            _httpClient = httpClientFactory.CreateClient("ExternalApi");
            _apiResponseHandlerService = apiResponseHandlerService;
        }

        public async Task<Result<string>> GetApiDataAsync()
        {
            var response = await _httpClient.GetAsync("/users");

            // Delegamos el manejo de errores al ApiResponseHandlerService
            return await _apiResponseHandlerService.HandleApiResponseAsync(response);
        }
    }
}
