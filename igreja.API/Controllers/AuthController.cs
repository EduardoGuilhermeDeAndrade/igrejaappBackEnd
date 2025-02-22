﻿using igreja.Application.DTOs;
using igreja.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("test-token")]
    public IActionResult TestToken()
    {
        var userId = User.FindFirst("userId")?.Value;
        var tenantId = User.FindFirst("tenantId")?.Value;
        return Ok(new { UserId = userId, TenantId = tenantId });
    }



    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var token = _authService.Login(loginDto.Username, loginDto.Password);
        if (token == null) return Unauthorized();
        return Ok(new { Token = token });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        await _authService.LogoutAsync(token);
        return Ok(new { message = "Logout successful" });
    }

}
