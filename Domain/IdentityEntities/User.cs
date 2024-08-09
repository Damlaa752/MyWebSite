using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using Domain.FileEntities;
using Domain.IdentityEntities;

namespace Domain.Identity
{
    public class User : BaseEntity
    {
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(255)]
        public string PasswordHash { get; set; }
        [StringLength(50)]
        public string Role { get; set; }

        public string Email { get; set; }
        public ICollection<FileEntity>? Files { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
        public ICollection<UserToken>? UserTokens { get; set; }
        public IEnumerable<Project>? Projects { get; }
        public IEnumerable<BlogPost>? BlogPosts { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
    }
}
