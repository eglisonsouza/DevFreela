using Devfreela.Aplication.Models.InputModels;
using Devfreela.Aplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Devfreela.API.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginInputModel login)
        {
            // TODO: Para Módulo de Autenticação e Autorização

            return NoContent();
        }
    }
}
