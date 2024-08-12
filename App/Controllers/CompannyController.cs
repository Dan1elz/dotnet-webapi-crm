using dotnet_webapi_erp.App.Models.Concrete.Company;
using dotnet_webapi_erp.App.Models.Concrete.Token;
using dotnet_webapi_erp.App.Models.Concrete.User;
using dotnet_webapi_erp.App.Services;
using dotnet_webapi_erp.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_erp.App.Controllers
{
    public class CompannyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUtilsService _utilsService;
        public CompannyController(ICompanyRepository companyRepository, ITokenRepository tokenRepository, IUtilsService utilsService)
        {
            _companyRepository = companyRepository;
            _tokenRepository = tokenRepository;
            _utilsService = utilsService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CompannyDTO request, CancellationToken ct)
        {
            try
            {
                var token = await _utilsService.GetToken(HttpContext.Request.Headers["Authorization"].ToString(), ct);
                if (token == null) return Unauthorized(new { message = "Token inválido ou não encontrado." });

                var company = new Company(request.Name, request.Description, token.UserId, request.NumberEmployees, request.CNPJ);

                var verifyCompanny = await _companyRepository.VerifyCompany(company, ct);
                if (verifyCompanny) return BadRequest(new { message = "Empresa já existente!" });

                await _companyRepository.Create(company, ct);

                return Ok(new { message = "Empresa criada com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro interno no servidor: " + ex.Message });
            }
        }

    }
}
