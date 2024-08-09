using dotnet_webapi_erp.App.Models.Concrete.Token;
namespace dotnet_webapi_erp.App.Services
{
    public interface IUtilsService
    {
        Task<Token?> GetToken(string token, CancellationToken ct);
    }
}
