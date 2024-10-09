using Microsoft.AspNetCore.Mvc;
using fisio_ltd_back.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace fisio_ltd_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamentoPropostoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TratamentoPropostoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/tratamentoproposto
        [HttpPost]
        public async Task<IActionResult> CreateTratamentoProposto(TratamentoProposto tratamento)
        {
            try
            {
                if (tratamento == null)
                {
                    return BadRequest("Dados do tratamento proposto não podem ser nulos.");
                }

                _context.TratamentosPropostos.Add(tratamento);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateTratamentoProposto), new { id = tratamento.Id }, tratamento);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados: " + ex.Message);
            }
        }

        // GET: api/tratamentoproposto
        [HttpGet]
        public async Task<IActionResult> GetTratamentosPropostos()
        {
            try
            {
                var tratamentos = await _context.TratamentosPropostos.ToListAsync();
                return Ok(tratamentos);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao recuperar dados do banco de dados: " + ex.Message);
            }
        }
    }
}
