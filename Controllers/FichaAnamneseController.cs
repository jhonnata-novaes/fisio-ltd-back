using Microsoft.AspNetCore.Mvc;
using fisio_ltd_back.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace fisio_ltd_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaAnamneseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FichaAnamneseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFichaAnamnese(FichaAnamnese fichaAnamnese)
        {
            try
            {
                // Salvando no banco de dados
                _context.FichasAnamnese.Add(fichaAnamnese);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateFichaAnamnese), new { id = fichaAnamnese.Id }, fichaAnamnese);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar no banco de dados: " + ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFichaAnamnesePorId(int id)
        {
            Console.WriteLine($"Requisição para obter paciente com ID: {id}");

            var fichaAnamnese = await _context.FichasAnamnese
                                    .Where(e => e.DadosBasicosId == id) 
                                    .ToListAsync();

            if (fichaAnamnese == null || !fichaAnamnese.Any())
            {
                return NotFound("A Ficha Anamnese não foi encontrada para este paciente.");
            }

            return Ok(fichaAnamnese); // Retorna a lista de exames encontrados
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFichaAnamnese(int id, FichaAnamnese fichaAnamnese)
        {
            if (id != fichaAnamnese.Id)
            {
                return BadRequest("O ID da ficha de anamnese não coincide com o ID fornecido.");
            }

            try
            {
                var fichaExistente = await _context.FichasAnamnese.FindAsync(id);
                if (fichaExistente == null)
                {
                    return NotFound("Ficha de anamnese não encontrada.");
                }

                // Atualizar os campos da ficha de anamnese existente
                fichaExistente.Queixa = fichaAnamnese.Queixa;
                fichaExistente.HistoriaDoencaAtual = fichaAnamnese.HistoriaDoencaAtual;
                fichaExistente.HistoriaPatologica = fichaAnamnese.HistoriaPatologica;
                fichaExistente.HabitosVida = fichaAnamnese.HabitosVida;
                fichaExistente.HistoriaFamiliar = fichaAnamnese.HistoriaFamiliar;

                _context.Entry(fichaExistente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent(); // Retorna 204 No Content em caso de sucesso
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FichaAnamneseExists(id))
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

        private bool FichaAnamneseExists(int id)
        {
            return _context.FichasAnamnese.Any(e => e.Id == id);
        }

    }
}
