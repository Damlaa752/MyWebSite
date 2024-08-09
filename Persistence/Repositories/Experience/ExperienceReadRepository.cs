using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Experience;
using Persistence.Contexts;

namespace Persistence.Repositories.Experience
{
    public class ExperienceReadRepository : ReadRepository<Domain.Entities.Experience>, IExperienceReadRepository
    {
        public ExperienceReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
