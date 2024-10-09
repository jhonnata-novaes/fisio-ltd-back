using Microsoft.AspNetCore.Mvc;
using fisio_ltd_back.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace fisio_ltd_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoPrognosticoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiagnosticoPrognosticoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/diagnosticoprogostico
        [HttpPost]
        public async Task<IActionResult> CreateDiagnosticoPrognostico(DiagnosticoPrognostico diagnostico)
        {
            try
            {
                if (diagnostico == null)
                {
                    return BadRequest("Dados do diagnóstico prognóstico não podem ser nulos.");
                }

                _context.DiagnosticosPrognosticos.Add(diagnostico);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateDiagnosticoPrognostico), new { id = diagnostico.Id }, diagnostico);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados: " + ex.Message);
            }
        }

        // GET: api/diagnosticoprogostico
        [HttpGet]
        public async Task<IActionResult> GetDiagnosticosPrognosticos()
        {
            try
            {
                var diagnosticos = await _context.DiagnosticosPrognosticos.ToListAsync();
                return Ok(diagnosticos);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao recuperar dados do banco de dados: " + ex.Message);
            }
        }
    }
}
