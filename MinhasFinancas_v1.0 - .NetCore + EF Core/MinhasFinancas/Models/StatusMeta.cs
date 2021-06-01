using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class StatusMeta
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O status não pode passar de 50 caracteres.")]
        public string Descricao { get; set; }
    }
}
