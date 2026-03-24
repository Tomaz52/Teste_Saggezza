[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _repo;
    private readonly JwtService _jwt;

    public AuthController(IUserRepository repo, JwtService jwt)
    {
        _repo = repo;
        _jwt = jwt;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        await _repo.Add(user);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _repo.GetByEmail(email);

        if (user == null || user.Password != password)
            return Unauthorized();

        var token = _jwt.Generate(user);
        return Ok(new { token });
    }
}