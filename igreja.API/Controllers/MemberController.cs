using igreja.Application.DTOs;
using igreja.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace igreja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _memberService.GetAllMembersAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MemberAddDto memberAddDto)
        {
            await _memberService.AddMemberAsync(memberAddDto);
            return CreatedAtAction(nameof(GetById), new { id = memberAddDto.Id }, memberAddDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MemberUpdateDto memberUpdateDto)
        {
            await _memberService.UpdateMemberAsync(id, memberUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _memberService.DeleteMemberAsync(id);
            return NoContent();
        }

        [HttpGet("igreja/{igrejaId}")]
        public async Task<IActionResult> GetByIgreja(Guid churchId)
        {
            var members = await _memberService.GetMembersByChurchAsync(churchId);
            return Ok(members);
        }
    }
}
