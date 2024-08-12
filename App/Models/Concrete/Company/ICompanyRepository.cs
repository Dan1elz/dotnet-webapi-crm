using dotnet_webapi_erp.Data.DTOs;

namespace dotnet_webapi_erp.App.Models.Concrete.Company
{
    public interface ICompanyRepository
    {
        Task<bool> VerifyCompany(Company company, CancellationToken ct);
        Task Create(Company company, CancellationToken ct);
        Task<object?> GetAll(Guid id, CancellationToken ct);
        Task<Company?> Get(Guid id, CancellationToken ct);
        Task Delete(Company company, CancellationToken ct);
        Task<Company?> Update(Company company, CancellationToken ct);
    }
}
