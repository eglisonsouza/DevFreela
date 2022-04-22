using Devfreela.Aplication.Models.ViewModels;
using Devfreela.Core.Repositories;
using MediatR;

namespace Devfreela.Aplication.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
