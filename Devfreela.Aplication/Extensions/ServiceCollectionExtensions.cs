using Devfreela.Core.Repositories;
using Devfreela.Infrastructure.Persistence;
using Devfreela.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Devfreela.Aplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInjectionDependecies(this IServiceCollection services)
        {
            services.AddDbContext<DevFreelaDbContext>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
        }
    }
}
