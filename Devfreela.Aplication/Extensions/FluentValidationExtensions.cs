using Devfreela.Aplication.Validators;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Devfreela.Aplication.Extensions
{
    public static class FluentValidationExtensions
    {
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<CreateCommentCommandValidator>());
            services.AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<CreateProjectCommandValidator>());
            services.AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());
            services.AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<UpdateProjectCommandValidator>());
        }
    }
}
