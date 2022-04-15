using Devfreela.Core.Entities;
using Devfreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Devfreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {

        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Skill>> GetAllAsync()
        {
            return _dbContext.Skills.ToListAsync();
        }
    }
}
