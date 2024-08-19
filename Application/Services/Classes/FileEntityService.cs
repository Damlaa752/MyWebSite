
// Application/Services/FileEntityService.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Application.Repositories;
using Application.Repositories.FileEntity;
using Application.Services.Interface;
using Domain.FileEntities;
using Microsoft.AspNetCore.Http;
using Application.DTO;
using Application.Services.Interface;
using Domain.Entities;

namespace Application.Services.Classes
{
    public class FileEntityService : IFileEntityService
    {
        private readonly IFileEntityWriteRepository _fileEntityWriteRepository;
        private readonly IFileEntityReadRepository _fileEntityReadRepository;
        //private readonly IWebHostEnvironment _environment;
        private readonly string _fileStoragePath = "wwwroot/images";

        public FileEntityService(IFileEntityWriteRepository fileEntityWriteRepository)
        {
            _fileEntityWriteRepository = fileEntityWriteRepository;
        }

        //public async Task<FileEntityDto> SaveFileAsync(IFormFile file, int? userId)
        //{
        //    // Upload klasörünün yolu
        //    var uploadPath = Path.Combine(_environment.ContentRootPath, "upload");

        //    // Klasör yoksa oluştur
        //    if (!Directory.Exists(uploadPath))
        //    {
        //        Directory.CreateDirectory(uploadPath);
        //    }

        //    // Dosya adı ve yolu
        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //    var filePath = Path.Combine(uploadPath, fileName);

        //    // Aynı isimde bir dosya olup olmadığını kontrol et
        //    while (File.Exists(filePath))
        //    {
        //        // Eğer aynı isimde dosya varsa, dosya adını değiştirelim
        //        fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //        filePath = Path.Combine(uploadPath, fileName);
        //    }

        //    // Dosyayı kaydet
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    var fileEntity = new FileEntity
        //    {
        //        FileName = fileName,
        //        FilePath = filePath, // Dosya yolu veritabanına kaydedilecek
        //        ContentType = file.ContentType,
        //        FileSize = file.Length,
        //        UploadDate = DateTime.UtcNow,
        //        UserId = userId
        //    };

        //    await _fileEntityWriteRepository.AddAsync(fileEntity);

        //    return new FileEntityDto
        //    {
        //        Id = fileEntity.ID,
        //        FileName = fileEntity.FileName,
        //        FilePath = fileEntity.FilePath, // Dosya yolunu döndürüyoruz
        //        ContentType = fileEntity.ContentType,
        //        FileSize = fileEntity.FileSize,
        //        UploadDate = fileEntity.UploadDate,
        //        UserId = fileEntity.UserId
        //    };

        //}

        public async Task<FileEntityDto> SaveFileAsync(IFormFile file, int? userId)
        {
            // Uygulamanın çalıştığı dizin
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Upload klasörünün yolu
            var uploadPath = Path.Combine(baseDirectory, "upload");

            // Klasör yoksa oluştur
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Dosya adı ve yolu
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            // Aynı isimde bir dosya olup olmadığını kontrol et
            while (File.Exists(filePath))
            {
                // Eğer aynı isimde dosya varsa, dosya adını değiştirelim
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(uploadPath, fileName);
            }

            // Dosyayı kaydet
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileEntity = new FileEntity
            {
                FileName = fileName,
                FilePath = filePath, // Dosya yolu veritabanına kaydedilecek
                ContentType = file.ContentType,
                FileSize = file.Length,
                UploadDate = DateTime.UtcNow,
                UserId = userId
            };

            await _fileEntityWriteRepository.AddAsync(fileEntity);

            return new FileEntityDto
            {
                Id = fileEntity.ID,
                FileName = fileEntity.FileName,
                FilePath = fileEntity.FilePath, // Dosya yolunu döndürüyoruz
                ContentType = fileEntity.ContentType,
                FileSize = fileEntity.FileSize,
                UploadDate = fileEntity.UploadDate,
                UserId = fileEntity.UserId
            };
        }


        // Diğer CRUD işlemleri aynı şekilde tanımlanabilir
        public async Task<FileEntityDto> UpdateFileAsync(int id, IFormFile file, int? userId)
        {
            var existingFile = await _fileEntityReadRepository.GetByIdAsync(id.ToString());
            if (existingFile == null)
                throw new Exception("File not found");

            // Eski dosyayı sil
            if (File.Exists(existingFile.FilePath))
            {
                File.Delete(existingFile.FilePath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_fileStoragePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            existingFile.FileName = fileName;
            existingFile.FilePath = filePath;
            existingFile.ContentType = file.ContentType;
            existingFile.FileSize = file.Length;
            existingFile.UploadDate = DateTime.UtcNow;
            existingFile.UserId = userId;

            _fileEntityWriteRepository.Update(existingFile);

            return new FileEntityDto
            {
                Id = existingFile.ID,
                FileName = existingFile.FileName,
                FilePath = existingFile.FilePath,
                ContentType = existingFile.ContentType,
                FileSize = existingFile.FileSize,
                UploadDate = existingFile.UploadDate,
                UserId = existingFile.UserId
            };
        }

        public async Task<bool> DeleteFileAsync(int id)
        {
            var existingFile = await _fileEntityReadRepository.GetByIdAsync(id.ToString());
            if (existingFile == null)
                return false;

            // Dosyayı sil
            if (File.Exists(existingFile.FilePath))
            {
                File.Delete(existingFile.FilePath);
            }

            _fileEntityWriteRepository.Remove(existingFile);
            return true;
        }

        public async Task<FileEntityDto> GetFileByIdAsync(int id)
        {
            var fileEntity = await _fileEntityReadRepository.GetByIdAsync(id.ToString());
            if (fileEntity == null)
                return null;

            return new FileEntityDto
            {
                Id = fileEntity.ID,
                FileName = fileEntity.FileName,
                FilePath = fileEntity.FilePath,
                ContentType = fileEntity.ContentType,
                FileSize = fileEntity.FileSize,
                UploadDate = fileEntity.UploadDate,
                UserId = fileEntity.UserId
            };
        }

        public  async Task<IEnumerable<FileEntityDto>> GetAllFilesAsync()
        {
            var fileEntities = _fileEntityReadRepository.GetAll();

            var fileEntityDtoList = new List<FileEntityDto>();
            foreach (var fileEntity in fileEntities)
            {
                fileEntityDtoList.Add(new FileEntityDto
                {
                    Id = fileEntity.ID,
                    FileName = fileEntity.FileName,
                    FilePath = fileEntity.FilePath,
                    ContentType = fileEntity.ContentType,
                    FileSize = fileEntity.FileSize,
                    UploadDate = fileEntity.UploadDate,
                    UserId = fileEntity.UserId
                });
            }

            return fileEntityDtoList;
        }
    }
}

