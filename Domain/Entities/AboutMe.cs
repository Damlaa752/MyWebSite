using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class AboutMe : BaseEntity
    {
        public string Introduction { get; set; }
        [MaxLength(255)]
        public string ImageUrl1 { get; set; }
        [MaxLength(255)]
        public string ImageUrl2 { get; set; }

    }
}
