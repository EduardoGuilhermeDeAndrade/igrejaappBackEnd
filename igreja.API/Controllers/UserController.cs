using AutoMapper;
using igreja.Application.DTOs;
using igreja.Domain.Models;
using Igreja.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    /// <summary>
    /// Obtém a lista de todos os usuários cadastrados.
    /// </summary>
    /// <returns>Uma lista de usuários</returns>
    [HttpGet("getAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync(); //Criar novo com ignore query filter
        if (users.Count() == 0)
            return NotFound();

        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

        return Ok(usersDto);
    }

    //[HttpGet("getByTenant")]
    //public async Task<IActionResult> GetAllUsersByTenant()
    //{
    //    var users = await _userRepository.GetUsersResponsableTaskAsync();
    //    if (users.Count() == 0)
    //        return NotFound();

    //    var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

    //    return Ok(usersDto);
    //}

    //[HttpGet("getIsResponsableTask")]
    //public async Task<IActionResult> GetUsersResponsableTask()
    //{
    //    var users = await _userRepository.GetUsersResponsableTaskAsync();
    //    if (users.Count() == 0)
    //        return NotFound();

    //    var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

    //    return Ok(usersDto);
    //}


    //[HttpPost("responsible-user-mark-toggle")]
    //public async Task<IActionResult> PostResponsibleUserMark(Guid userId)
    //{
    //    var user = await _userRepository.GetUserByIdIgnoreQueryFilterAsync(userId);

    //    if (user == null)
    //        return BadRequest("Este usuário não existe.");

    //    if (string.IsNullOrEmpty(user.Email))
    //        return BadRequest("Este usuário não possui e-mail cadastrado.");

    //    user.IsResponsableMyTask = !user.IsResponsableMyTask;
    //    await _userRepository.UpdateAsync(user);

    //    return Ok();
    //}

}
