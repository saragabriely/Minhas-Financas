using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class Ano
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int Descricao { get; set; }
    }
}
