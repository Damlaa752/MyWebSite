using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.AboutMe;
using Persistence.Contexts;

namespace Persistence.Repositories.AboutMe
{
    public class AboutMeReadRepository : ReadRepository<Domain.Entities.AboutMe>, IAboutMeReadRepository
    {
        public AboutMeReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
