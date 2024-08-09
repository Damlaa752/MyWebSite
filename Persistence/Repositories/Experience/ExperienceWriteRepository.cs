using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Experience;
using Persistence.Contexts;

namespace Persistence.Repositories.Experience
{
    public class ExperienceWriteRepository : WriteRepository<Domain.Entities.Experience>, IExperinceWriteRepository
    {
        public ExperienceWriteRepository(DataDbContext context) : base(context)
        {
        }
    }
}
