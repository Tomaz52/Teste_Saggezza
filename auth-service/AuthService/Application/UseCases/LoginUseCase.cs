using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;

namespace AuthService.Application.UseCases;

public class LoginUseCase
{
    private readonly IUserRepository _repository;
    private readonly JwtService _jwtService;

    public LoginUseCase(IUserRepository repository, JwtService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    public async Task<string> Execute(string email, string password)
    {
        var user = await _repository.GetByEmail(email);

        if (user == null || user.Password != password)
            throw new Exception("Credenciais inválidas");

        return _jwtService.Generate(user);
    }
}