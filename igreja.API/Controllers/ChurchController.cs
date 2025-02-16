using igreja.Application.DTOs.Church;
using igreja.Application.Interfaces;
using igreja.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace church.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Garante que somente usuários autenticados acessem
    public class ChurchController : ControllerBase
    {
        private readonly IChurchService _churchService;

        public ChurchController(IChurchService churchService)
        {
            _churchService = churchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var churchs = await _churchService.GetAllChurchsAsync();
            return Ok(churchs);
        }

        [HttpGet("get-all-with-temples-name")]
        public async Task<IActionResult> GetAllWithTemplesName()
        {
            var churchs = await _churchService.GetAllWithTemplesNameAsync();
            return Ok(churchs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var church = await _churchService.GetChurchByIdAsync(id);
            return Ok(church);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChurchAddDto churchAddDto)
        {
            if (churchAddDto == null)
                return BadRequest(new ApiResponse<string>("Dados inválidos para criação da igreja.", false));
            var response = await _churchService.AddChurchAsync(churchAddDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ChurchUpdateDto churchUpdateDto)
        {
            var response = await _churchService.UpdateChurchAsync(id, churchUpdateDto);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _churchService.DeleteChurchAsync(id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
