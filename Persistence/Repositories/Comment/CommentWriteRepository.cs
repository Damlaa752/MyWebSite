using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Comment;
using Persistence.Contexts;

namespace Persistence.Repositories.Comment
{
    public class CommentWriteRepository : WriteRepository<Domain.Entities.Comment>, ICommentWriteRepository
    {
        public CommentWriteRepository(DataDbContext context) : base(context)
        {
        }
    }
}
