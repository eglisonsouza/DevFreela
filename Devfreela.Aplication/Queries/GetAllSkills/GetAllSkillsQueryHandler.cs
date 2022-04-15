using Devfreela.Aplication.Models.ViewModels;
using Devfreela.Core.Repositories;
using MediatR;

namespace Devfreela.Aplication.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly ISkillRepository _skillRepository;
        public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllAsync();
            return skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();
        }
    }
}
