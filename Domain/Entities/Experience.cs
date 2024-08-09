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
    public class Experience : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
