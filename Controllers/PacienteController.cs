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
            try
            {
                // Convertendo DataNascimento e DataAvaliacao para UTC
                dadosBasicos.DataNascimento = DateTime.SpecifyKind(dadosBasicos.DataNascimento, DateTimeKind.Utc);
                if (dadosBasicos.DataAvaliacao.HasValue) // Verifica se DataAvaliacao está presente
                {
                    dadosBasicos.DataAvaliacao = DateTime.SpecifyKind(dadosBasicos.DataAvaliacao.Value, DateTimeKind.Utc);
                }

                // Salvando no banco de dados
                _context.DadosBasicos.Add(dadosBasicos);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreatePaciente), new { id = dadosBasicos.Id }, dadosBasicos);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados: " + ex.Message);
            }
        }

        // GET: api/paciente
        [HttpGet]
        public async Task<IActionResult> GetPacientes()
        {
            try
            {
                var pacientes = await _context.DadosBasicos.ToListAsync();
                return Ok(pacientes);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao recuperar dados do banco de dados: " + ex.Message);
            }
        }
    }
}
