using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class StatusDespesa
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O status não pode passar de 50 caracteres.")]
        public string Descricao { get; set; }
        
        public const int APagar   = 1;
        public const int Pago     = 2;
        public const int EmAtraso = 3;
        public const int Todos    = 4;
    }
}
