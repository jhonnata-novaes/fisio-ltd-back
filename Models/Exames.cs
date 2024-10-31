using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class Exames
    {
        [Key]
        public int Id { get; set; } // Identificador único do exame

        public int DadosBasicosId { get; set; } // Referência ao registro de Dados Básicos

        public string? ExamesComplementares { get; set; } // Campo para armazenar exames complementares
        public string? ExameFisico { get; set; } // Campo para armazenar informações do exame físico

        public virtual DadosBasicos DadosBasicos { get; set; }
    }
}
