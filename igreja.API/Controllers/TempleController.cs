using igreja.Application.DTOs.Temple;
using igreja.Application.Interfaces;
using igreja.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace igreja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TempleController : ControllerBase
    {
        private readonly ITempleService _templeService;

        public TempleController(ITempleService templeService)
        {
            _templeService = templeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var temples = await _templeService.GetAllTemplesAsync();
            return Ok(temples);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var temple = await _templeService.GetTempleByIdAsync(id);
            return Ok(temple);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TempleAddDto templeAddDto)
        {
            if (templeAddDto == null)
                return BadRequest(new ApiResponse<string>("Dados inválidos para criação de templo.", false));

            var response = await _templeService.AddTempleAsync(templeAddDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TempleUpdateDto templeUpdateDto)
        {
            var response = await _templeService.UpdateTempleAsync(id, templeUpdateDto);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _templeService.DeleteTempleAsync(id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("igreja/{igrejaId}")]
        public async Task<IActionResult> GetByIgreja(Guid igrejaId)
        {
            var temples = await _templeService.GetTemplesByChurchAsync(igrejaId);
            return Ok(temples);
        }
    }
}
