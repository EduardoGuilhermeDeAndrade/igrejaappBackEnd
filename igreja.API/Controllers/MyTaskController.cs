using igreja.Application.DTOs.MyTask;
using igreja.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace igreja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class MyTaskController : ControllerBase
    {
        private readonly IMyTaskService _myTaskService;
        private readonly IAttachmentService _attachmentService;

        public MyTaskController(IMyTaskService myTaskService, IAttachmentService attachmentService)
        {
            _myTaskService = myTaskService;
            _attachmentService = attachmentService;
        }

        [HttpGet("get-my-tasks-by-filter")]
        public async Task<IActionResult> GetMyTaskByFilter(
            [FromQuery] string? title,
            [FromQuery] bool? isCompleted,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var response = await _myTaskService.GetMyTaskByFilterAsync(title, isCompleted, page, pageSize);
            if (response == null)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMyTasks()
        {
            var response = await _myTaskService.GetAllMyTasksAsync();
            if (response == null)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get-tasks-assigned-to-me")]
        public async Task<IActionResult> GetTasksAssignedToMe()
        {
            var response = await _myTaskService.GetTasksAssignedToMeAsync();
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("get-tasks-issued-by-me")]
        public async Task<IActionResult> GetTasksIssuedByMe()
        {
            var response = await _myTaskService.GetTasksIssuedByMeAsync();
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMyTask([FromBody] MyTaskUpdateDto myTaskUpdateDto)
        {
            var response = await _myTaskService.UpdateMyTaskAsync(myTaskUpdateDto);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyTask([FromRoute] Guid id)
        {
            var response = await _myTaskService.DeleteLogicMyTaskAsync(id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }


        /// <summary>
        /// Endpoint para baixar o anexo (imagem ou outro arquivo).
        /// </summary>
        /// <param name="id">ID do anexo para download.</param>
        /// <returns>Arquivo para download.</returns>
        [HttpGet("download/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DownloadAttachment(Guid id)
        {
            var attachment = await _attachmentService.GetAttachmentByIdAsync(id);

            if (attachment == null)
            {
                return NotFound("Anexo não encontrado.");
            }

            var fileBytes = attachment.Data;
            var fileName = attachment.FileName;
            var contentType = attachment.ContentType;

            return File(fileBytes, contentType, fileName);
        }




        /// <summary>
        /// Upload de anexo para uma tarefa.
        /// </summary>
        /// <param name="file">Arquivo para upload.</param>
        /// <returns>Detalhes do anexo salvo.</returns>
        [HttpPost("upload-attachment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadAttachment(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido.");

            try
            {
                var attachment = await _attachmentService.SaveAttachmentAsync(file);
                return Ok(new
                {
                    Id = attachment.Id,
                    FileName = attachment.FileName,
                    ContentType = attachment.ContentType,
                    UploadedAt = attachment.UploadedAt
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar o anexo: {ex.Message}");
            }
        }
    }
}

