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
    public class Project : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
