using AuthService.Application.Interfaces;
using AuthService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public LoginUseCase(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Execute(string username, string password)
        {
            // 🔍 Busca usuário no banco
            var user = await _userRepository.GetByUsername(username);

            if (user == null || user.Password != password)
                throw new Exception("Usuário ou senha inválidos");

            // 🔐 Gera token 
            var token = _jwtService.GenerateToken(user.Id, user.Role);

            return token;
        }
    }
}
