using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class TratamentoProposto
    {
        public int Id { get; set; } // Identificação única

        public int PacienteId { get; set; } // Chave estrangeira para DadosBasicos

        [Required(ErrorMessage = "O Plano Terapêutico é obrigatório.")]
        public required string PlanoTeraputico { get; set; }

        // Propriedades de navegação
        public virtual DadosBasicos? Paciente { get; set; } // Tornada anulável

        // Construtor
        public TratamentoProposto()
        {
            // Paciente não precisa ser inicializado no construtor
        }
    }
}
