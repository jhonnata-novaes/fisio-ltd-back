using Microsoft.AspNetCore.Mvc;
using fisio_ltd_back.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace fisio_ltd_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/paciente
        [HttpPost]
        public async Task<IActionResult> CreatePaciente(DadosBasicos dadosBasicos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DadosBasicos.Add(dadosBasicos);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreatePaciente), new { id = dadosBasicos.Id }, dadosBasicos);
        }

        // GET: api/paciente
        [HttpGet]
        public async Task<IActionResult> GetPacientes()
        {
            var pacientes = await _context.DadosBasicos.ToListAsync();
            return Ok(pacientes);
        }
    }
}
