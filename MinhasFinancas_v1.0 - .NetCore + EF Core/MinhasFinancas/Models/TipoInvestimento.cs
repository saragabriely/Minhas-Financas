using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class TipoInvestimento
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A descrição do tipo de investimento não pode passar de 100 caracteres.")]
        public string Descricao { get; set; }
    }
}
