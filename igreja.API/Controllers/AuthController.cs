using igreja.Application.DTOs;
using igreja.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")] //Comentário de testes de commit
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var token = _authService.Login(loginDto.Username, loginDto.Password);
        if (token == null) return Unauthorized();
        return Ok(new { Token = token });
    }
}
