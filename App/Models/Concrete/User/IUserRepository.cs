using dotnet_webapi_erp.App.Models.Concrete;
using TokenNamespace = dotnet_webapi_erp.App.Models.Concrete.Token;
using System.Threading;
using dotnet_webapi_erp.Data.DTOs;

namespace dotnet_webapi_erp.App.Models.Concrete.User
{
    public interface IUserRepository
    {
        void Create(User user, CancellationToken ct);
        Task<UserDTO?> GetUser(TokenNamespace.Token token, CancellationToken ct);
        Task<string?> Login(string email, string password, CancellationToken ct);
        Task<string?> Update(TokenNamespace.Token token, User user, CancellationToken ct);
        void Delete(TokenNamespace.Token token, CancellationToken ct);
    }
}
