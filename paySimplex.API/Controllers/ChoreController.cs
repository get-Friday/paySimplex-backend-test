﻿using Microsoft.AspNetCore.Mvc;
using paySimplex.Domain.DTOs;
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
        public IActionResult GetAll()
        {
            return Ok(_choreService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] int id
        )
        {
            return Ok(_choreService.GetById(id));
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
    }
}
