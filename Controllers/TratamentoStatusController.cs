using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fisio_ltd_back.Models;
using System.Threading.Tasks;

namespace fisio_ltd_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamentoStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TratamentoStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Endpoint para finalizar tratamento
        [HttpPut("finalizar/{id}")]
        public async Task<IActionResult> FinalizarTratamento(int id)
        {
            var status = await _context.TratamentoStatus
                                       .FirstOrDefaultAsync(s => s.DadosBasicosId == id);

            if (status == null)
            {
                return NotFound(new { message = "Status de tratamento não encontrado." });
            }

            // Finaliza o tratamento
            status.Finalizado = true;
            status.Cancelado = false; // Caso o tratamento seja finalizado, não pode estar cancelado

            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna status 204 (sem conteúdo) indicando sucesso
        }

        // Endpoint para cancelar tratamento
        [HttpPut("cancelar/{id}")]
        public async Task<IActionResult> CancelarTratamento(int id)
        {
            var status = await _context.TratamentoStatus
                                       .FirstOrDefaultAsync(s => s.DadosBasicosId == id);

            if (status == null)
            {
                return NotFound(new { message = "Status de tratamento não encontrado." });
            }

            // Cancela o tratamento
            status.Cancelado = true;
            status.Finalizado = false; // Caso o tratamento seja cancelado, não pode estar finalizado

            _context.Entry(status).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna status 204 (sem conteúdo) indicando sucesso
        }

        // Endpoint para obter o status de tratamento de um paciente
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusTratamento(int id)
        {
            var status = await _context.TratamentoStatus
                                       .FirstOrDefaultAsync(s => s.DadosBasicosId == id);

            if (status == null)
            {
                return NotFound(new { message = "Status de tratamento não encontrado." });
            }

            return Ok(status); // Retorna o status de tratamento do paciente
        }
    }
}
