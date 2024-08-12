using dotnet_webapi_erp.App.Models.Concrete.Company;
using dotnet_webapi_erp.App.Models.Concrete.User;
using dotnet_webapi_erp.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_erp.Data.Repositories
{
    public class CompanyRepository(AppDbContext context) : ICompanyRepository
    {
        private readonly AppDbContext _context = context;


        public async Task<bool> VerifyCompany(Company company, CancellationToken ct)
        {
            var verify = await _context.Company
                .SingleOrDefaultAsync(u => u.CNPJ == company.CNPJ, ct);
            return verify == null ? false : true;
        }
        public async Task Create(Company company, CancellationToken ct)
        {
            await _context.Company.AddAsync(company, ct);
            await _context.SaveChangesAsync(ct);
        }
        public async Task<object?> GetAll(Guid id, CancellationToken ct)
        {
            var companys = await _context.Company
                .Where(u => u.Owner == id)
                .Select(u => new { u.Name, u.Description }).ToListAsync(ct);
            return companys ?? null;
        }
        public async Task<Company?> Get(Guid id, CancellationToken ct) 
        { 
            var company = await _context.Company
                .FirstOrDefaultAsync(u => u.Id == id, ct);
            return company ?? null;
        }
        public async Task Delete(Company company, CancellationToken ct)
        {
            _context.Company.Remove(company);
            await _context.SaveChangesAsync(ct);
        }
        public async Task<Company?> Update(Company company, CancellationToken ct)
        {
            var verifyCompany = await _context.Company
                .SingleOrDefaultAsync(u => u.CNPJ ==  company.CNPJ, ct);
           
            if (verifyCompany == null) return null;
            
            verifyCompany.Update(verifyCompany);
            await _context.SaveChangesAsync(ct);

            return verifyCompany ?? null;
        }
    }
}
