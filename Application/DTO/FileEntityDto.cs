using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.DTO
{
    public class FileEntityDto
    {
        //public IFormFile File { get; set; }
        //public int? UserId { get; set; }
        public int Id { get; set; } // Benzersiz kimlik
        public string FileName { get; set; } // Dosya adı
        public string FilePath { get; set; } // Dosya yolu
        public string ContentType { get; set; } // Dosya türü (MIME type)
        public long FileSize { get; set; } // Dosya boyutu
        public DateTime UploadDate { get; set; } // Yüklenme tarihi

        // Kullanıcıyla ilişki
        public int? UserId { get; set; } // Kullanıcı kimliği
    }

}
