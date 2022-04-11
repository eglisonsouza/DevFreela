using Devfreela.Aplication.Commands.CreateComment;
using Devfreela.Aplication.Commands.CreateProject;
using Devfreela.Aplication.Commands.CreateUser;
using Devfreela.Aplication.Commands.DeleteProject;
using Devfreela.Aplication.Commands.FinishProject;
using Devfreela.Aplication.Commands.StartProject;
using Devfreela.Aplication.Commands.UpdateProject;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Devfreela.Aplication.Extensions
{
    public static class MediatRExtensions
    {

        public static void AddMediatDependencies(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateProjectCommand));
            services.AddMediatR(typeof(CreateCommentCommand));
            services.AddMediatR(typeof(CreateUserCommand));
            services.AddMediatR(typeof(DeleteProjectCommand));
            services.AddMediatR(typeof(FinishProjectCommand));
            services.AddMediatR(typeof(StartProjectCommand));
            services.AddMediatR(typeof(UpdateProjectCommand));
        }

    }
}
