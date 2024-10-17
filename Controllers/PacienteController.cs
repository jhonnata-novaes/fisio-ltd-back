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
                dadosBasicos.DataNascimento = DateTime.SpecifyKind(dadosBasicos.DataNascimento, DateTimeKind.Utc);
                
                // Trata a DataAvaliacao como anulável
                if (dadosBasicos.DataAvaliacao.HasValue)
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPacientePorId(int id)
        {
            Console.WriteLine($"Requisição para obter paciente com ID: {id}");

            var paciente = await _context.DadosBasicos.FindAsync(id);
            if (paciente == null)
            {
                return NotFound("Paciente não encontrado.");
            }

            return Ok(paciente);
        }

        
        // PUT: api/paciente/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPaciente(int id, DadosBasicos dadosBasicos)
        {
            if (id != dadosBasicos.Id)
            {
                return BadRequest("O ID do paciente não coincide com o ID fornecido.");
            }

            try
            {
                var pacienteExistente = await _context.DadosBasicos.FindAsync(id);
                if (pacienteExistente == null)
                {
                    return NotFound("Paciente não encontrado.");
                }

                // Atualizar os campos do paciente existente
                pacienteExistente.Nome = dadosBasicos.Nome;

                // A DataAvaliacao é anulável, então atribuímos diretamente
                pacienteExistente.DataAvaliacao = dadosBasicos.DataAvaliacao.HasValue 
                    ? DateTime.SpecifyKind(dadosBasicos.DataAvaliacao.Value, DateTimeKind.Utc) 
                    : (DateTime?)null;

                pacienteExistente.EstadoCivil = dadosBasicos.EstadoCivil;
                pacienteExistente.Nacionalidade = dadosBasicos.Nacionalidade;
                pacienteExistente.Naturalidade = dadosBasicos.Naturalidade;

                // A DataNascimento não é anulável
                pacienteExistente.DataNascimento = DateTime.SpecifyKind(dadosBasicos.DataNascimento, DateTimeKind.Utc);

                pacienteExistente.Peso = dadosBasicos.Peso;
                pacienteExistente.Altura = dadosBasicos.Altura;
                pacienteExistente.Endereco = dadosBasicos.Endereco;
                pacienteExistente.NumeroIdentidade = dadosBasicos.NumeroIdentidade;
                pacienteExistente.Telefone = dadosBasicos.Telefone;
                pacienteExistente.Email = dadosBasicos.Email;
                pacienteExistente.Profissao = dadosBasicos.Profissao;
                pacienteExistente.DiagnosticoClinico = dadosBasicos.DiagnosticoClinico;

                _context.Entry(pacienteExistente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent(); // Retorna 204 No Content em caso de sucesso
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
                {
                    return NotFound("Paciente não encontrado.");
                }
                else
                {
                    throw; // Relança a exceção se houver outro erro
                }
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao atualizar os dados do paciente: " + ex.Message);
            }
        }

        private bool PacienteExists(int id)
        {
            return _context.DadosBasicos.Any(e => e.Id == id);
        }
    }
}
