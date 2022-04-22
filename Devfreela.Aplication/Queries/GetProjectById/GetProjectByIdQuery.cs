using Devfreela.Aplication.Models.ViewModels;
using MediatR;

namespace Devfreela.Aplication.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
