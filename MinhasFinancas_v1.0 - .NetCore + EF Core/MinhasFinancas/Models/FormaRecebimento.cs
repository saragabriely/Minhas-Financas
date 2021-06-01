using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class FormaRecebimento
    {
        [Key]
        [Required]
        public int FormaRecebimento_ID { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "A forma de recebimento não pode passar de 80 caracteres.")]
        public string Descricao { get; set; }
    }
}
