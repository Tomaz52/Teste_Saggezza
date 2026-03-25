using AuthService.Application.Interfaces;
using AuthService.Application.UseCases;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace AuthService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;
        private readonly IUserRepository _userRepository;

        public AuthController(LoginUseCase loginUseCase, IUserRepository userRepository)
        {
            _loginUseCase = loginUseCase;
            _userRepository = userRepository;
        }

        //  DTOs internos (simples para MVP)
        public class RegisterRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        //  REGISTRO
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = request.Password, // ⚠️ depois você pode aplicar hash
                Role = "User"
            };

            await _userRepository.Add(user);

            return Ok(new { message = "Usuário criado com sucesso" });
        }

        //  LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _loginUseCase.Execute(request.Username, request.Password);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}