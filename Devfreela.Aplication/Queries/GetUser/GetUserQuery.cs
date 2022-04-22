using Devfreela.Aplication.Models.ViewModels;
using MediatR;

namespace Devfreela.Aplication.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
