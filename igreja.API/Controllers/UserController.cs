using AutoMapper;
using igreja.Application.DTOs;
using igreja.Domain.Models;
using Igreja.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersResponsableTask()
    {
        var users = await _userRepository.GetUsersResponsableTaskAsync();
        if (users.Count() == 0)
            return NotFound();

        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

        return Ok(usersDto);
    }


    [HttpPost("responsible-user-mark-toggle")]
    public async Task<IActionResult> PostResponsibleUserMark(Guid userId)
    {
        var user = await _userRepository.GetByIdIgnoreQueryFilterAsync(userId);

        if (user == null)
            return BadRequest("Este usuário não existe.");

        if (string.IsNullOrEmpty(user.Email))
            return BadRequest("Este usuário não possui e-mail cadastrado.");

        user.IsResponsableMyTask = !user.IsResponsableMyTask;
        await _userRepository.UpdateAsync(user);

        return Ok();
    }

}
