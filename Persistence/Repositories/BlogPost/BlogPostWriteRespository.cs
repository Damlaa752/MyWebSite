using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.BlogPost;

namespace Persistence.Repositories.BlogPost
{
    public class BlogPostWriteRespository : WriteRepository<Domain.Entities.BlogPost>, IBlogPostWriteRepository
    {
        public BlogPostWriteRespository(DataDbContext context) : base(context)
        {
        }
    }
}
