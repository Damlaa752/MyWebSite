using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Service;
using Persistence.Contexts;

namespace Persistence.Repositories.Service
{
    public class ServiceReadRepository : ReadRepository<Domain.Entities.Service>, IServiceReadRepository
    {
        public ServiceReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
