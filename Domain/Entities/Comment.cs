using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Identity;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public int? BlogPostID { get; set; }
        public int? UserID { get; set; }
        public BlogPost? BlogPost { get; set; }
        public User? User { get; set; }
    }
}
