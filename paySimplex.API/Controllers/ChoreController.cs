using Microsoft.AspNetCore.Mvc;
using paySimplex.Domain.DTOs;
using paySimplex.Domain.Enums;
using paySimplex.Domain.Interfaces.Services;

namespace paySimplex.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoreController : ControllerBase
    {
        private readonly IChoreService _choreService;
        public ChoreController(IChoreService choreService)
        {
            _choreService = choreService;
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] int? userId,
            [FromQuery] Status? status,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate
        )
        {
            return Ok(_choreService.GetAll(userId, status, startDate, endDate));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] int id
        )
        {
            return Ok(_choreService.GetById(id));
        }

        [HttpGet("user/{id}")]
        public IActionResult GetByUserId(
            [FromRoute] int id
        )
        {
            return Ok(_choreService.GetByUserId(id));
        }

        [HttpPost]
        public IActionResult Insert(
            [FromBody] ChoreDTO choreDTO    
        )
        {
            _choreService.Insert(choreDTO);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(
            [FromRoute] int id,
            [FromBody] ChoreDTO choreDTO
        )
        {
            _choreService.Update(choreDTO, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            [FromRoute] int id    
        )
        {
            _choreService.Delete(id);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPatch("{id}/status/{status}")]
        public IActionResult ChangeStatus(
            [FromRoute] int id,    
            [FromRoute] Status status
        )
        {
            _choreService.ChangeStatus(status, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
