using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.ContactMessage;
using Persistence.Contexts;

namespace Persistence.Repositories.ContactMessage
{
    public class ContactMessageReadRepository : ReadRepository<Domain.Entities.ContactMessage>, IContactMessageReadRepository
    {
        public ContactMessageReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
