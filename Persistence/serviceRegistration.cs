using Application.Repositories.AboutMe;
using Application.Repositories.BlogPost;
using Application.Repositories.Comment;
using Application.Repositories.ContactMessage;
using Application.Repositories.Education;
using Application.Repositories.Experience;
using Application.Repositories.FileEntity;
using Application.Repositories.PersonalInfo;
using Application.Repositories.Project;
using Application.Repositories.Service;
using Application.Repositories.User;
using Application.Repositories.UserRole;
using Application.Repositories.UserToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories.AboutMe;
using Persistence.Repositories.BlogPost;
using Persistence.Repositories.Comment;
using Persistence.Repositories.ContactMessage;
using Persistence.Repositories.Education;
using Persistence.Repositories.Experience;
using Persistence.Repositories.FileEntity;
using Persistence.Repositories.PersonalInfo;
using Persistence.Repositories.Project;
using Persistence.Repositories.Service;
using Persistence.Repositories.User;
using Persistence.Repositories.UserRole;
using Persistence.Repositories.UserToken;

namespace Persistence
{
    public class serviceRegistration
    {
        public static void AddPersistenceServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<FileDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            // FileDbContext için yapılandırma
            services.AddDbContext<FileDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyWebSiteFile")));

            // AuthDbContext için yapılandırma
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyWebSiteAuth")));

            // DataDbContext için yapılandırma
            services.AddDbContext<DataDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyWebSiteData")));

            //Enitites
            services.AddScoped<IAboutMeReadRepository, AboutMeReadRepository>();
            services.AddScoped<IAboutMeReadRepository, AboutMeWriteRepository>();

            services.AddScoped<IBlogPostReadRepository, BlogPostReadRepository>();
            services.AddScoped<IBlogPostWriteRepository, BlogPostWriteRespository>();

            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();

            services.AddScoped<IContactMessageReadRepository, ContactMessageReadRepository>();
            services.AddScoped<IContactMessageWriteRepository, ContactMessageWriteRepository>();

            services.AddScoped<IEducationReadRepository, EducationReadRepository>();
            services.AddScoped<IEducationWriteRepository, EducationWriteRepository>();

            services.AddScoped<IExperienceReadRepository, ExperienceReadRepository>();
            services.AddScoped<IExperinceWriteRepository, ExperienceWriteRepository>();

            services.AddScoped<IFileEntityReadRepository, FileEntityReadRepository>();
            services.AddScoped<IFileEntityWriteRepository, FileEntityWriteRepository>();

            services.AddScoped<IPersonelInfoReadRepository, PersonalInfoReadRepository>();
            services.AddScoped<IPersonelInfoWriteRepository, PersonalInfoWriteRepository>();

            services.AddScoped<IProjectReadRepository, ProjectReadRepository>();
            services.AddScoped<IProjectWriteRepository, ProjectWriteRepository>();

            services.AddScoped<IServiceReadRepository, ServiceReadRepository>();
            services.AddScoped<IServiceWriteRepository, ServiceWriteRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IUserRoleReadRepository, UserRoleReadRepository>();
            services.AddScoped<IUserRoleWriteRepository, UserRoleWriteRepository>();

            services.AddScoped<IUserTokenReadRepository, UserTokenReadRepository>();
            services.AddScoped<IUserTokenWriteRepository, UserTokenWriteRepository>();
        }
    }
}
