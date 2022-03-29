using Devfreela.Aplication.Services.Implementations;
using Devfreela.Aplication.Services.Interfaces;
using Devfreela.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Devfreela.Aplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddSingleton<DevFreelaDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
