using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.FileEntity;
using Persistence.Contexts;

namespace Persistence.Repositories.FileEntity
{
    public class FileEntityReadRepository : FileReadRepository<Domain.FileEntities.FileEntity>, IFileEntityReadRepository
    {
        public FileEntityReadRepository(FileDbContext context) : base(context)
        {
        }
    }
}
