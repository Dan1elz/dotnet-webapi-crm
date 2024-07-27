using dotnet_webapi_erp.App.Models.Concrete.Token;
using dotnet_webapi_erp.App.Models.Concrete.User;
using dotnet_webapi_erp.App.Services;
using dotnet_webapi_erp.Data.DTOs;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_erp.Data.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public async void Create(User user, CancellationToken ct)
        {
            await _context.User.AddAsync(user, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async void Delete(Token token, CancellationToken ct)
        {
            var user = await _context.User.FindAsync(new object?[] { token.UserId, ct }, cancellationToken: ct);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.Token.Remove(token);
                await _context.SaveChangesAsync(ct);
            }
        }

        public async Task<UserDTO?> GetUser(Token token, CancellationToken ct)
        {
          var user = await _context.User
                .Where(u => u.Id == token.UserId)
                .Select(u => new UserDTO(u.Id, u.Name, u.Lastname, u.Email, u.CPF, u.PhoneNumber, u.Created, u.Updated))
                .SingleOrDefaultAsync(ct);

                return user;
        }

        public async Task<object?> Login(string email, string password, CancellationToken ct)
        {

            var login = await _context.User
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == password, ct);

            if (login == null)
                return "Falha ao autentificar. Verifique os dados enviados";

            return {login.Id ?: false};

            var tokenVerify = await _context.Token
                .Where(u => u.UserId == login.Id)
                .FirstOrDefaultAsync(ct);
            return tokenVerify?.Value ?? "Token não encontrado";
        }

        public async Task<string?> Update(Token token, User user, CancellationToken ct)
        {
            var verifyUser = await _context.User
                .SingleOrDefaultAsync(u => u.Id == token.UserId && u.Email == user.Email && u.Password == user.Password, ct);
            if (verifyUser == null) return "Os dados não são condizentes.";

            verifyUser.Update(user);
            _context.Token.Remove(token);
            await _context.SaveChangesAsync(ct);

            var createToken = TokenService.GenerateToken(user.Id);

            var newToken = new Token(verifyUser.Id, createToken.Value);
            await _context.Token.AddAsync(newToken, ct);
            await _context.SaveChangesAsync(ct);

            return "Usuário atualizado com sucesso."; ;
        }
    }
}
