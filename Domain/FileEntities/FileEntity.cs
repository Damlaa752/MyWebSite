using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.FileEntities
{
    public class FileEntity : BaseEntity
    {
        public string FileName { get; set; } // Dosya adı
        public string FilePath { get; set; } // Dosya yolu
        public string ContentType { get; set; } // Dosya türü (MIME type)
        public long FileSize { get; set; } // Dosya boyutu
        public DateTime UploadDate { get; set; } // Yüklenme tarihi

        // Foreign key relation with User entity
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
