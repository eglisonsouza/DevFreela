using Devfreela.Core.Entities;
using Devfreela.Core.Repositories;
using Devfreela.Infrastructure.Persistence;
using MediatR;

namespace Devfreela.Aplication.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate);
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}