using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.PersonalInfo;
using Persistence.Contexts;

namespace Persistence.Repositories.PersonalInfo
{
    public class PersonalInfoReadRepository : ReadRepository<Domain.Entities.PersonalInfo>, IPersonelInfoReadRepository
    {
        public PersonalInfoReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
