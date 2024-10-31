using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fisio_ltd_back.Models
{
    public class TratamentoProposto
    {
        [Key]
        public int Id { get; set; }
        
        // Chave estrangeira para o modelo DadosBasicos
        public int DadosBasicosId { get; set; }

        // Propriedade que representa o plano de tratamento
        public string? Plano { get; set; }
        
        // Navegação para o modelo DadosBasicos (opcional, caso queira incluir a referência)
        [ForeignKey("DadosBasicosId")]
        public virtual DadosBasicos? DadosBasicos { get; set; }
    }
}
