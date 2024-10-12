using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class DiagnosticoPrognostico
    {
        [Key]
        public int Id { get; set; }
        public int DadosBasicosId { get; set; }
        public string? DiagnosticoFisio { get; set; } 
        public string? PrognosticoFisio { get; set; } 
        public string? Quantidade { get; set; }

    }
}
