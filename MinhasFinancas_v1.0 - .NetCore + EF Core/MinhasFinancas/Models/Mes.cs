using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class Mes
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int NumeroMes { get; set; }
    }
}
