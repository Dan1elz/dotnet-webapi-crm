
using dotnet_webapi_erp.App.Services;
using Microsoft.EntityFrameworkCore;
using dotnet_webapi_erp.App.Models.Concrete.Token;
using dotnet_webapi_erp.App.Models.Concrete.User;

namespace dotnet_webapi_erp.Data.Repositories
{
    public class TokenRepository(AppDbContext context) : ITokenRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Token> Create(Guid Id, CancellationToken ct)
        {
            var createToken = TokenService.GenerateToken(Id);

            var newToken = new Token(Id, createToken.Value);
            await _context.Token.AddAsync(newToken, ct);
            await _context.SaveChangesAsync(ct);

            return newToken;
        }

        public async Task<Token?> Reuse(Guid Id, CancellationToken ct) 
        {
            var tokenVerify = await _context.Token
                .Where(u => u.UserId == Id)
                .FirstOrDefaultAsync(ct);
            
            if (tokenVerify != null) 
                return tokenVerify;

            return null;
        }

        public async Task<Token?> GetToken(string _token, CancellationToken ct)
        {
            var token = await _context.Token
                .FirstOrDefaultAsync(u => u.Value == _token, ct);

            if (token != null) return token;

            return null;
        }

        public async Task Delete(Token token, CancellationToken ct)
        {
            _context.Token.Remove(token);
            await _context.SaveChangesAsync(ct);
        }
    }
}
