using Microsoft.AspNetCore.Mvc;
using MICRUDGABRIEL.Contract;
using MICRUDGABRIEL.Dtos;

namespace MICRUDGABRIEL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrainerDto dto)
        {
            var result = await _trainerService.CreateAsync(dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _trainerService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trainer = await _trainerService.GetByIdAsync(id);
            if (trainer == null) return NotFound("Entrenador no encontrado");
            return Ok(trainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrainerDto dto)
        {
            var result = await _trainerService.UpdateAsync(id, dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _trainerService.DeleteAsync(id);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
