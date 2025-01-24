using System;
using System.Net.Http;
using System.Threading.Tasks;
using UserDashboardBuilder.Core;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace UserDashboardBuilder.Core.Interfaces
{
    public interface IApiResponseHandlerService
    {
        Task<Result<string>> HandleApiResponseAsync(HttpResponseMessage response);
    }
}
