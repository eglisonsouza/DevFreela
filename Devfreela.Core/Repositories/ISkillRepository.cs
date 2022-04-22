using Devfreela.Core.Entities;

namespace Devfreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
    }
}
