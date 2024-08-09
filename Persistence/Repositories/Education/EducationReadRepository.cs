using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Education;
using Persistence.Contexts;

namespace Persistence.Repositories.Education
{
    public class EducationReadRepository : ReadRepository<Domain.Entities.Education>, IEducationReadRepository
    {
        public EducationReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
