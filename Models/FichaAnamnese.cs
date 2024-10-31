using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class FichaAnamnese
    {
        [Key]
        public int Id { get; set; }

        public int DadosBasicosId { get; set; }  // Relaciona com DadosBasicos
        public DadosBasicos DadosBasicos { get; set; }  // Propriedade de navegação para DadosBasicos

        public string? Queixa { get; set; }
        public string? HistoriaDoencaAtual { get; set; }
        public string? HistoriaPatologica { get; set; }
        public string? HabitosVida { get; set; }
        public string? HistoriaFamiliar { get; set; }
    }
}
