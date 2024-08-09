using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Project;
using Persistence.Contexts;

namespace Persistence.Repositories.Project
{
    public class ProjectReadRepository : ReadRepository<Domain.Entities.Project>, IProjectReadRepository
    {
        public ProjectReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
