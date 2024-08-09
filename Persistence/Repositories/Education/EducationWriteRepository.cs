using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Education;
using Persistence.Contexts;

namespace Persistence.Repositories.Education
{
    public class EducationWriteRepository : WriteRepository<Domain.Entities.Education>, IEducationWriteRepository
    {
        public EducationWriteRepository(DataDbContext context) : base(context)
        {
        }
    }
}
