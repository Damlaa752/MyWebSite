using Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.FileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileEntityController : ControllerBase
    {
        private readonly IFileEntityService _fileEntityService;

        public FileEntityController(IFileEntityService fileEntityService)
        {
            _fileEntityService = fileEntityService;
        }
        // Dosya yükleme işlemi
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, int? userId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is not selected");

            var result = await _fileEntityService.SaveFileAsync(file, userId);
            return Ok(result);
        }

        // Dosya güncelleme işlemi
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFile(int id, IFormFile file, int? userId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is not selected");

            var existingFile = await _fileEntityService.GetFileByIdAsync(id);
            if (existingFile == null)
                return NotFound("File not found");

            // Mevcut dosyayı güncelle
            var result = await _fileEntityService.UpdateFileAsync(id, file, userId);
            return Ok(result);
        }

        // Dosya silme işlemi
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var existingFile = await _fileEntityService.GetFileByIdAsync(id);
            if (existingFile == null)
                return NotFound("File not found");

            var result = await _fileEntityService.DeleteFileAsync(id);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete the file.");

            return NoContent();
        }

        // Tek dosya alma işlemi
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileById(int id)
        {
            var result = await _fileEntityService.GetFileByIdAsync(id);
            if (result == null)
                return NotFound("File not found");

            return Ok(result);
        }

        // Tüm dosyaları listeleme işlemi
        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            var result = await _fileEntityService.GetAllFilesAsync();
            return Ok(result);
        }
    }
}
