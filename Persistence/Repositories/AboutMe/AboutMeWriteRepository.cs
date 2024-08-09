using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Application.Repositories.AboutMe;
using Persistence.Contexts;

namespace Persistence.Repositories.AboutMe
{
    public class AboutMeWriteRepository : WriteRepository<Domain.Entities.AboutMe>, IAboutMeWriteRepository, IAboutMeReadRepository
    {
        public AboutMeWriteRepository(DataDbContext context) : base(context)
        {
        }
    }
}
