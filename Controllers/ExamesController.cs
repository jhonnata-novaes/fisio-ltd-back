using Microsoft.AspNetCore.Mvc;
using fisio_ltd_back.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace fisio_ltd_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExame(Exames exame)
        {
            try
            {
                // Salvando no banco de dados
                _context.Exames.Add(exame);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateExame), new { id = exame.Id }, exame);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados: " + ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamesPorId(int id)
        {
            Console.WriteLine($"Requisição para obter exames do paciente com ID: {id}");

            // Buscar exames associados ao paciente
            var exames = await _context.Exames
                                    .Where(e => e.DadosBasicosId == id) // Verifica se há exames para o paciente específico
                                    .ToListAsync();

            if (exames == null || !exames.Any())
            {
                return NotFound("Exames não encontrados para este paciente.");
            }

            return Ok(exames); // Retorna a lista de exames encontrados
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarExames(int id, Exames exames)
        {
            if (id != exames.Id)
            {
                return BadRequest("O ID da ficha de anamnese não coincide com o ID fornecido.");
            }

            try
            {
                var exameExistente = await _context.Exames.FindAsync(id);
                if (exameExistente == null)
                {
                    return NotFound("Ficha de anamnese não encontrada.");
                }

                // Atualizar os campos da ficha de anamnese existente
                exameExistente.ExamesComplementares = exames.ExamesComplementares;
                exameExistente.ExameFisico = exames.ExameFisico;

                _context.Entry(exameExistente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent(); // Retorna 204 No Content em caso de sucesso
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamesExists(id))
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

        private bool ExamesExists(int id)
        {
            return _context.Exames.Any(e => e.Id == id);
        }

    }
}
