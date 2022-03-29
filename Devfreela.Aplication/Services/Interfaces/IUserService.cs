using Devfreela.Aplication.Models.InputModels;
using Devfreela.Aplication.Models.ViewModels;

namespace Devfreela.Aplication.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        int Create(CreateUserInputModel inputModel);
    }
}
