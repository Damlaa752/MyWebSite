using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.ContactMessage;

namespace Persistence.Repositories.ContactMessage
{
    public class ContactMessageWriteRepository : WriteRepository<Domain.Entities.ContactMessage>, IContactMessageWriteRepository
    {
        public ContactMessageWriteRepository(DataDbContext context) : base(context)
        {
        }
    }
}
