using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models.Investimentos.RendaVariavel
{
    public class SetorEmpresa
    {
        [Key]
        [Required]
        public int ID { get; set; }
        
        [MaxLength(150, ErrorMessage ="A descrição tem tamanho máximo de 150 caracteres.")]
        public string descricao { get; set; }
    }
}
