using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Comment;
using Persistence.Contexts;

namespace Persistence.Repositories.Comment
{
    public class CommentReadRepository : ReadRepository<Domain.Entities.Comment>, ICommentReadRepository
    {
        public CommentReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
