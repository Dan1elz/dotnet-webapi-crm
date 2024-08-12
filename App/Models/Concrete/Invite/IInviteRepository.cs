namespace dotnet_webapi_erp.App.Models.Concrete.Invite
{
    public interface IInviteRepository
    {
        List<Invite> ListAll(Guid user);

        Task<object> ListByValue(string value, Guid user, CancellationToken ct);

        Task Confirm(Guid Inivit, CancellationToken ct);
    }
}
