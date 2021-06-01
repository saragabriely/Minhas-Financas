using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class TipoConta
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "O tipo de conta não pode passar de 40 caracteres.")]
        public string Descricao { get; set; }
    }
}
