using Microsoft.AspNetCore.Mvc;
using paySimplex.Domain.DTOs;
using paySimplex.Domain.Interfaces.Services;

namespace paySimplex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] int id    
        )
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPost]
        public IActionResult Insert(
            [FromBody] UserDTO userDTO
        )
        {
            _userService.Insert(userDTO);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] UserDTO userDTO
        )
        {
            _userService.Update(userDTO, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromRoute] int id
        )
        {
            _userService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
