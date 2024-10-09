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

        // POST: api/exames
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

        // GET: api/exames
        [HttpGet]
        public async Task<IActionResult> GetExames()
        {
            try
            {
                var exames = await _context.Exames.ToListAsync();
                return Ok(exames);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao recuperar dados do banco de dados: " + ex.Message);
            }
        }
    }
}
