using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class TratamentoProposto
    {
        [Key]
        public int Id { get; set; }
        public int DadosBasicosId { get; set; }
        public string? Plano { get; set; }
    }
}
