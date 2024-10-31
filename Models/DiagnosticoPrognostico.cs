using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class DiagnosticoPrognostico
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key for DadosBasicos
        public int DadosBasicosId { get; set; }

        // Navigation property for DadosBasicos
        [ForeignKey("DadosBasicosId")]
        public virtual DadosBasicos DadosBasicos { get; set; } // Adiciona a propriedade de navegação

        public string? DiagnosticoFisio { get; set; } 
        public string? PrognosticoFisio { get; set; } 
        public string? Quantidade { get; set; }
    }
}
