using dotnet_webapi_erp.App.Models.Concrete.User;
using dotnet_webapi_erp.Data;
using dotnet_webapi_erp.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_erp.App.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public async IActionResult Create(CreateUserDTO request, CancellationToken ct)
        {
            try
            {
               
                return;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro interno no servidor: " + ex.Message });

            }

        }
    }
}
