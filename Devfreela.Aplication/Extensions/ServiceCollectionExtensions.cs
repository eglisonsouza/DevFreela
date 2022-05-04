using Devfreela.Aplication.Consumers;
using Devfreela.Core.Repositories;
using Devfreela.Core.Services;
using Devfreela.Infrastructure.Auth;
using Devfreela.Infrastructure.Persistence;
using Devfreela.Infrastructure.Persistence.Repositories;
using Devfreela.Infrastructure.Services;
using DevFreela.Shared.Models.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Devfreela.Aplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInjectionDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DevFreelaDbContext>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();
            services.AddHostedService<PaymentApprovedConsumer>();
            services.AddSingleton(configuration.GetSection("Settings").Get<ApiSettings>());

        }
    }
}
