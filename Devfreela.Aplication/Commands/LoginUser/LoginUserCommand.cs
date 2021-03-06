using Devfreela.Aplication.ViewModels;
using MediatR;

namespace Devfreela.Aplication.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
