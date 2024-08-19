using Application.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IFileEntityService
    {
        Task<FileEntityDto> SaveFileAsync(IFormFile file, int? userId);
        Task<FileEntityDto> UpdateFileAsync(int id, IFormFile file, int? userId);
        Task<bool> DeleteFileAsync(int id);
        Task<FileEntityDto> GetFileByIdAsync(int id);
        Task<IEnumerable<FileEntityDto>> GetAllFilesAsync();
    }
}
