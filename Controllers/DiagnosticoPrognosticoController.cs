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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiagnosticoPorId(int id)
        {
            Console.WriteLine($"Requisição para obter paciente com ID: {id}");

            var diagnostico = await _context.DiagnosticoPrognostico
                                    .Where(e => e.DadosBasicosId == id) 
                                    .ToListAsync();
            if (diagnostico == null || !diagnostico.Any())
            {
                return NotFound("Diagnostico não encontrado.");
            }

            return Ok(diagnostico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarDiagnostico(int id, DiagnosticoPrognostico diagnostico)
        {
            if (id != diagnostico.Id)
            {
                return BadRequest("O ID da ficha de anamnese não coincide com o ID fornecido.");
            }

            try
            {
                var diagnosticoExistente = await _context.DiagnosticoPrognostico.FindAsync(id);
                if (diagnosticoExistente == null)
                {
                    return NotFound("Ficha de anamnese não encontrada.");
                }

                // Atualizar os campos da ficha de anamnese existente
                diagnosticoExistente.DiagnosticoFisio = diagnostico.DiagnosticoFisio;
                diagnosticoExistente.PrognosticoFisio = diagnostico.PrognosticoFisio;
                diagnosticoExistente.Quantidade = diagnostico.Quantidade;

                _context.Entry(diagnosticoExistente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent(); // Retorna 204 No Content em caso de sucesso
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosticoPrognosticoExists(id))
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

        private bool DiagnosticoPrognosticoExists(int id)
        {
            return _context.DiagnosticoPrognostico.Any(e => e.Id == id);
        }

    }
}
