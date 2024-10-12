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

        [HttpPost]
        public async Task<IActionResult> CreateDiagnosticoPrognostico(DiagnosticoPrognostico diagnostico)
        {
            try
            {
                // Salvando no banco de dados
                _context.DiagnosticoPrognostico.Add(diagnostico);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateDiagnosticoPrognostico), new { id = diagnostico.Id }, diagnostico);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados: " + ex.Message);
            }
        }

        // [HttpGet]
        // public async Task<IActionResult> GetDiagnosticoPrognostico()
        // {
        //     try
        //     {
        //         var diagnostico = await _context.DiagnosticoPrognostico.Include(e => e.DadosBasicos).ToListAsync();
        //         return Ok(diagnostico);
        //     }
        //     catch (DbUpdateException ex)
        //     {
        //         return StatusCode(500, "Erro ao recuperar dados do banco de dados: " + ex.Message);
        //     }
        // }
    }
}
