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

        [HttpPost]
        public async Task<IActionResult> CreateTratamentoProposto(TratamentoProposto tratamento)
        {
            try
            {
                // Salvando no banco de dados
                _context.TratamentoProposto.Add(tratamento);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateTratamentoProposto), new { id = tratamento.Id }, tratamento);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados: " + ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTratamentoPropostoPorId(int id)
        {
            Console.WriteLine($"Requisição para obter paciente com ID: {id}");

            var tratamento = await _context.TratamentoProposto
                                    .Where(e => e.DadosBasicosId == id)
                                    .ToListAsync();

            if (tratamento == null || !tratamento.Any())
            {
                return NotFound("Tratamento não encontrados para este paciente.");
            }

            return Ok(tratamento); // Retorna a lista de exames encontrados
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTratamentoProposto(int id, TratamentoProposto tratamento)
        {
            if (id != tratamento.Id)
            {
                return BadRequest("O ID da ficha de anamnese não coincide com o ID fornecido.");
            }

            try
            {
                var tratamentoExistente = await _context.TratamentoProposto.FindAsync(id);
                if (tratamentoExistente == null)
                {
                    return NotFound("Ficha de anamnese não encontrada.");
                }

                // Atualizar os campos da ficha de anamnese existente
                tratamentoExistente.Plano = tratamento.Plano;

                // Verificar se o status foi alterado, se não, define como "Pendente"
                if (string.IsNullOrEmpty(tratamentoExistente.StatusTratamento))
                {
                    tratamentoExistente.StatusTratamento = "Pendente"; // Define como Pendente se não informado
                }

                _context.Entry(tratamentoExistente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent(); // Retorna 204 No Content em caso de sucesso
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TratamentoPropostoExists(id))
                {
                    return NotFound("Ficha de anamnese não encontrada.");
                }
                else
                {
                    throw; // Relança a exceção se houver outro erro
                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao atualizar os dados da ficha de anamnese: " + ex.Message);
            }
        }

        private bool TratamentoPropostoExists(int id)
        {
            return _context.TratamentoProposto.Any(e => e.Id == id);
        }


        [HttpPut("finalizar/{id}")]
        public async Task<IActionResult> FinalizarTratamento(int id)
        {
            var tratamentoExistente = await _context.TratamentoProposto.FindAsync(id);
            if (tratamentoExistente == null)
            {
                return NotFound("Tratamento não encontrado.");
            }

            tratamentoExistente.StatusTratamento = "Finalizado";
            _context.Entry(tratamentoExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna 204 No Content em caso de sucesso
        }

        [HttpPut("cancelado/{id}")]
        public async Task<IActionResult> AtualizarStatusCancelado(int id)
        {
            var tratamentoExistente = await _context.TratamentoProposto.FindAsync(id);
            if (tratamentoExistente == null)
            {
                return NotFound("Tratamento não encontrado.");
            }

            tratamentoExistente.StatusTratamento = "Cancelado";
            _context.Entry(tratamentoExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna 204 No Content em caso de sucesso
        }
    }
}
