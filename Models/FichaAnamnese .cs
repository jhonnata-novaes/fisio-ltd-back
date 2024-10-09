using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class FichaAnamnese
    {
        public int Id { get; set; } // Identificação única

        public int PacienteId { get; set; } // Chave estrangeira para DadosBasicos

        [Required(ErrorMessage = "A Queixa é obrigatória.")]
        public required string Queixa { get; set; }

        [Required(ErrorMessage = "A História da Doença Atual é obrigatória.")]
        public required string HistoriaDoencaAtual { get; set; }

        [Required(ErrorMessage = "A História Patológica é obrigatória.")]
        public required string HistoriaPatologica { get; set; }

        [Required(ErrorMessage = "Os Hábitos de Vida são obrigatórios.")]
        public required string HabitosVida { get; set; }

        [Required(ErrorMessage = "A História Familiar é obrigatória.")]
        public required string HistoriaFamiliar { get; set; }

        // Propriedades de navegação
        public virtual DadosBasicos? Paciente { get; set; } // Tornada anulável

        // Construtor
        public FichaAnamnese()
        {
            // Paciente não precisa ser inicializado no construtor
        }
    }
}
