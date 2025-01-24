using System;
using System.Net.Http;
using System.Threading.Tasks;
using UserDashboardBuilder.Core;
using UserDashboardBuilder.Core.Interfaces;
using Polly;
/// <summary>
/// Summary description for Class1
/// </summary>

namespace UserDashboardBuilder.Infrastructure.Services
{
    public class ApiResponseHandlerService : IApiResponseHandlerService
    {
        public async Task<Result<string>> HandleApiResponseAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return Result<string>.Success(responseData);
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            return Result<string>.Failure($"Error: {response.StatusCode}, Content: {errorContent}");
        }
    }
}
