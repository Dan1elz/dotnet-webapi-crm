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

        public async Task Create(User user, CancellationToken ct)
        {
            await _context.User.AddAsync(user, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<bool> Delete(Token token, CancellationToken ct)
        {
            var user = await _context.User.FindAsync(new object?[] { token.UserId, ct }, cancellationToken: ct);
            if (user == null) return false;
                
            _context.User.Remove(user);
            _context.Token.Remove(token);
            await _context.SaveChangesAsync(ct);
            
            return true;
        }

        public async Task<UserDTO?> GetUser(Token token, CancellationToken ct)
        {
          var user = await _context.User
                .Where(u => u.Id == token.UserId)
                .Select(u => new UserDTO(u.Id, u.Name, u.Lastname, u.Email, u.CPF, u.PhoneNumber, u.Created, u.Updated))
                .SingleOrDefaultAsync(ct);

                return user ?? null;
        }

        public async Task<User?> Login(string email, string password, CancellationToken ct)
        {
            return await _context.User
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == password, ct);
        }

        public async Task<bool> Update(Token token, UpdateUserDTO user, CancellationToken ct)
        {
            var verifyUser = await _context.User
                .SingleOrDefaultAsync(u => u.Id == token.UserId && u.Email == user.Email && u.Password == user.Password, ct);
            if (verifyUser == null) return false;

            verifyUser.Update(user);
            _context.Token.Remove(token);
            await _context.SaveChangesAsync(ct);

            return true;
        }

        public async Task<bool> VerifyUser(User user, CancellationToken ct)
        {
            var verifyUser = await _context.User
               .SingleOrDefaultAsync(u => u.Email == user.Email, ct);
            return verifyUser == null ? false : true;
        }
    }
}




