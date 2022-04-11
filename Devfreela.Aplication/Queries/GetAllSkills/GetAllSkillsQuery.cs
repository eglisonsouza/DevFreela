using Devfreela.Aplication.Models.ViewModels;
using MediatR;

namespace Devfreela.Aplication.Queries.GetAllSkills
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
    }
}
