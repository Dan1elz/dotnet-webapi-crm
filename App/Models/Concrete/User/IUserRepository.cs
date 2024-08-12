using dotnet_webapi_erp.App.Models.Concrete;
using TokenNamespace = dotnet_webapi_erp.App.Models.Concrete.Token;
using System.Threading;
using dotnet_webapi_erp.Data.DTOs;

namespace dotnet_webapi_erp.App.Models.Concrete.User
{
    public interface IUserRepository
    {
        Task Create(User user, CancellationToken ct);
        Task<UserDTO?> GetUser(TokenNamespace.Token token, CancellationToken ct);
        Task<User?> Login(string email, string password, CancellationToken ct);
        Task<bool> Update(TokenNamespace.Token token, UpdateUserDTO user, CancellationToken ct);
        Task<bool> Delete(TokenNamespace.Token token, CancellationToken ct);
        Task<bool> VerifyUser(User user, CancellationToken ct);
    }
}
