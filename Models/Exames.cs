using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class Exames
    {
        public int Id { get; set; } // Identificação única

        public int PacienteId { get; set; } // Chave estrangeira para DadosBasicos

        [Required(ErrorMessage = "Os Exames Complementares são obrigatórios.")]
        public required string ExamesComplementares { get; set; }

        [Required(ErrorMessage = "O Exame Físico-Funcional é obrigatório.")]
        public required string ExameFisicoFuncional { get; set; }

        // Propriedades de navegação
        public virtual DadosBasicos? Paciente { get; set; } // Tornada anulável

        // Construtor
        public Exames()
        {
            // Paciente não precisa ser inicializado no construtor
        }
    }
}
