using Devfreela.Aplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Devfreela.API.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_skillService.GetAll());
        }
    }
}
