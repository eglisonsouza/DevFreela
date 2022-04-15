using Devfreela.Aplication.ViewModels;
using Devfreela.Core.Repositories;
using Devfreela.Core.Services;
using MediatR;

namespace Devfreela.Aplication.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        public readonly IAuthService _authService;
        public readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = await _userRepository.GetByEmailAndPasswordAsync(email: request.Email, password: passwordHash);

            if (user == null)
            {
                return new LoginUserViewModel();
            }

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUserViewModel(user.Email, token);
        }
    }
}
