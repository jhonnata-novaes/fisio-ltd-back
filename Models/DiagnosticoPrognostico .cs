using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class DiagnosticoPrognostico
    {
        public int Id { get; set; } // Identificação única

        public int PacienteId { get; set; } // Chave estrangeira para DadosBasicos

        [Required(ErrorMessage = "O Diagnóstico Fisioterapêutico é obrigatório.")]
        public required string DiagnosticoFisio { get; set; }

        [Required(ErrorMessage = "O Prognóstico Fisioterapêutico é obrigatório.")]
        public required string PrognosticoFisio { get; set; }

        [Required(ErrorMessage = "A Quantidade Provável de Atendimentos é obrigatória.")]
        public required string QuantidadeAtendimentos { get; set; }

        // Propriedades de navegação
        public virtual DadosBasicos? Paciente { get; set; } // Tornada anulável

        // Construtor
        public DiagnosticoPrognostico()
        {
            // Paciente não precisa ser inicializado no construtor
        }
    }
}
