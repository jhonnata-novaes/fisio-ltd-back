using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class DadosBasicos
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataAvaliacao { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Nacionalidade { get; set; }
        public string? Naturalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Altura { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroIdentidade { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Profissao { get; set; }
        public string? DiagnosticoClinico { get; set; }
    }
}