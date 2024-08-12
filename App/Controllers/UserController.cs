using dotnet_webapi_erp.App.Models.Concrete.Token;
using dotnet_webapi_erp.App.Models.Concrete.User;
using dotnet_webapi_erp.App.Services;
using dotnet_webapi_erp.Data;
using dotnet_webapi_erp.Data.DTOs;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace dotnet_webapi_erp.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IUtilsService _utilsService;
        public UserController(IUserRepository userRepository, ITokenRepository tokenRepository, IUtilsService utilsService)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _utilsService = utilsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO request, CancellationToken ct)
        {
            try
            {
                var user = new User(request.Name, request.Lastname, request.Email, request.CPF, request.PhoneNumber, request.Password, request.DataNascimento);
                
                var verify = await _userRepository.VerifyUser(user, ct);

                if(verify)
                    return BadRequest(new { message = "Usuario já existente!"});

                await _userRepository.Create(user, ct);

                return Ok(new { message = "Usuário criado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro interno no servidor: " + ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO request, CancellationToken ct)
        {
            try
            {
                var user = await _userRepository.Login(request.Email, request.Password, ct);

                if (user == null)
                    return BadRequest(new { message = "Usuario não encontrado!" });

                var token = await _tokenRepository.Reuse(user.Id, ct);
                if(token != null)
                    return Ok(new { data = token.Value, message = "Token Reutilizado" });

                token = await _tokenRepository.Create(user.Id, ct);
                    return Ok(new { data = token.Value, message = "Token Criado" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro interno no servidor: " + ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var token = await _utilsService.GetToken(HttpContext.Request.Headers["Authorization"].ToString(), ct);

            if (token == null) return Unauthorized(new { message = "Token inválido ou não encontrado." });

            var user = await _userRepository.GetUser(token, ct);
            if (user == null)
                return Conflict(error: "Usuario não encontrado.");

            return Ok(new { data = user, message = "Usuario logado com sucesso!" });
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UpdateUserDTO request, CancellationToken ct) 
        {
            
            var token = await _utilsService.GetToken(HttpContext.Request.Headers["Authorization"].ToString(), ct);

            if (token == null) return Unauthorized(new { message = "Token inválido ou não encontrado." });

            if (request == null)
                return BadRequest(new { message = "Requisição inválida." });

            var update = await _userRepository.Update(token, request, ct);

            if (!update)
                return BadRequest(new { message = "Erro ao atualizar usuario, verifique os dados de entrada." });

            token = await _tokenRepository.Create(token.UserId, ct);

            return Ok(new { data = token!.Value, message = "Usuario atualizado com sucesso!" });
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(CancellationToken ct)
        {
            var token = await _utilsService.GetToken(HttpContext.Request.Headers["Authorization"].ToString(), ct);

            if (token == null) return Unauthorized(new { message = "Token inválido ou não encontrado." });

            var delete = await _userRepository.Delete(token, ct);

            if (!delete) return BadRequest(new { message = "Erro ao deletar usuario!" });

            return Ok(new { message = "Usuario deletado com sucesso!" });
        }
    }
}