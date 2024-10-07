using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class DadosBasicos
    {
        public int Id { get; set; } // Identificação única

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public required string Nome { get; set; }  // Modificado para 'required'

        [Required(ErrorMessage = "A Data da Avaliação é obrigatória.")]
        public DateTime? DataAvaliacao { get; set; } // Tornar anulável

        [Required(ErrorMessage = "O Estado Civil é obrigatório.")]
        public required string EstadoCivil { get; set; }  // Modificado para 'required'

        [Required(ErrorMessage = "A Nacionalidade é obrigatória.")]
        public required string Nacionalidade { get; set; }  // Modificado para 'required'

        [Required(ErrorMessage = "A Naturalidade é obrigatória.")]
        public required string Naturalidade { get; set; }  // Modificado para 'required'

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Peso é obrigatório.")]
        [Column(TypeName = "decimal(5, 2)")] // Define precisão para PostgreSQL
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "A Altura é obrigatória.")]
        [Column(TypeName = "decimal(5, 2)")] // Define precisão para PostgreSQL
        public decimal Altura { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        public required string Endereco { get; set; }  // Modificado para 'required'

        [Required(ErrorMessage = "O Nº Identidade é obrigatório.")]
        public required string NumeroIdentidade { get; set; }  // Modificado para 'required'

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        public required string Telefone { get; set; }  // Modificado para 'required'

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email não é válido.")]
        public required string Email { get; set; }  // Modificado para 'required'

        [Required(ErrorMessage = "A Profissão é obrigatória.")]
        public required string Profissao { get; set; }  // Modificado para 'required'

        public string? DiagnosticoClinico { get; set; } // Tornado anulável
    }
}
