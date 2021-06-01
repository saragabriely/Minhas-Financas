using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class StatusReceita
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "O status não pode passar de 30 caracteres.")]
        public string Descricao { get; set; }

        public const int AReceber = 1;
        public const int Recebido = 2;
        public const int Pendente = 3;
        public const int Todos    = 4;
    }
}
