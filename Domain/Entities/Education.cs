using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain.Entities
{
    public class Education : BaseEntity
    {
        [MaxLength(50)]
        public string Degree { get; set; }
        [MaxLength(100)]
        public string School { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
