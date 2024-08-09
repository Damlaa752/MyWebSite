using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.FileEntity;

namespace Persistence.Repositories.FileEntity
{
    public class FileEntityWriteRepository : FileWriteRepository<Domain.FileEntities.FileEntity>, IFileEntityWriteRepository
    {
        public FileEntityWriteRepository(FileDbContext context) : base(context)
        {
        }
    }
}
