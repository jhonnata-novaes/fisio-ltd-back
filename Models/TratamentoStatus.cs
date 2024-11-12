using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class TratamentoStatus
    {
        [Key]
        public int Id { get; set; }

        // Relacionamento com DadosBasicos (Paciente)
        public int DadosBasicosId { get; set; }

        // Indicadores de status do tratamento
        public bool Finalizado { get; set; }
        public bool Cancelado { get; set; }

        // Data de atualização do status
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;

        // Relacionamento com DadosBasicos
        public DadosBasicos DadosBasicos { get; set; }
    }
}
