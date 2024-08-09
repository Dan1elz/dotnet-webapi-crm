namespace dotnet_webapi_erp.App.Models.Concrete.Token
{
    public interface ITokenRepository
    {
        Task<Token> Create(Guid Id, CancellationToken ct);
        Task<Token?> Reuse(Guid Id, CancellationToken ct);
        Task Delete(Token token, CancellationToken ct);
        Task<Token?> GetToken(string _token, CancellationToken ct);
    }
}
