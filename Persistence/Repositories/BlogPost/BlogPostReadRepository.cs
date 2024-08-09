using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.BlogPost;
using Persistence.Contexts;

namespace Persistence.Repositories.BlogPost
{
    public class BlogPostReadRepository : ReadRepository<Domain.Entities.BlogPost>, IBlogPostReadRepository
    {
        public BlogPostReadRepository(DataDbContext context) : base(context)
        {
        }
    }
}
