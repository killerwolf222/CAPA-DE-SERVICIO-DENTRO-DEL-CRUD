using Microsoft.AspNetCore.Mvc;
using MICRUDGABRIEL.Contract;
using MICRUDGABRIEL.Dtos;

namespace MICRUDGABRIEL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        // POST: api/member
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MemberDto dto)
        {
            var result = await _memberService.CreateAsync(dto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/member
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _memberService.GetAllAsync();
            return Ok(members);
        }

        // GET: api/member/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
                return NotFound("Miembro no encontrado");

            return Ok(member);
        }

        // PUT: api/member/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MemberDto dto)
        {
            var result = await _memberService.UpdateAsync(id, dto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/member/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _memberService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
