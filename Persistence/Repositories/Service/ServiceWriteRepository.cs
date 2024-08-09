using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Service;
using Persistence.Contexts;

namespace Persistence.Repositories.Service
{
    public class ServiceWriteRepository : WriteRepository<Domain.Entities.Service>, IServiceWriteRepository
    {
        public ServiceWriteRepository(DataDbContext context) : base(context)
        {
        }
    }
}
