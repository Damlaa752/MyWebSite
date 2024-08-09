using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Identity;

namespace Domain.Entities
{
    public class BlogPost : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int? UserID { get; set; }
        public int? CommentID { get; set; }
        public User? User { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
    }
}
