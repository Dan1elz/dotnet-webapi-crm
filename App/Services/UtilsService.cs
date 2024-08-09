using dotnet_webapi_erp.App.Models.Concrete.Token;

namespace dotnet_webapi_erp.App.Services
{
    public class UtilsService : IUtilsService
    {
        private readonly ITokenRepository _tokenRepository;

        public UtilsService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public async Task<Token?> GetToken(string token, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                return null;

            token = token.Substring("Bearer ".Length).Trim();

            Token? result = await _tokenRepository.GetToken(token, ct);

            return result;
        }
    }
}
