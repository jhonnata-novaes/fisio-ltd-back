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

        // GET: api/FichaAnamnese
        [HttpGet]
        public async Task<IActionResult> GetFichasAnamnese()
        {
            try
            {
                var fichas = await _context.FichasAnamnese.Include(f => f.DadosBasicos).ToListAsync();
                return Ok(fichas);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao recuperar dados do banco de dados: " + ex.Message);
            }
        }
    }
}
