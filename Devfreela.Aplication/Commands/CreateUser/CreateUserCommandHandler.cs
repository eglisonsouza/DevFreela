using Devfreela.Core.Entities;
using Devfreela.Core.Repositories;
using Devfreela.Core.Services;
using MediatR;

namespace Devfreela.Aplication.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate, _authService.ComputeSha256Hash(request.Password), request.Role);
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}