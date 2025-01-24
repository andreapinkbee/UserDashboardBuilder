using System;
using System.Threading.Tasks;
using UserDashboardBuilder.Core;

/// <summary>
/// Interface for ExternalApiService
/// </summary>
namespace UserDashboardBuilder.Core.Interfaces
{
    public interface IExternalApiService
    {
        Task<Result<string>> GetApiDataAsync();
    }
}
