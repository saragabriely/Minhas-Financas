using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class TipoReceita
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "O tipo de receita não pode passar de 80 caracteres.")]
        [MinLength(4, ErrorMessage = "O Tipo de Receita deve ter mais de 4 caracteres.")]
        public string Descricao { get; set; }
        
        public const int Salario = 1;
        public const int DecimoTercSalario = 2;
        public const int Bonus      = 3;
        public const int Reembolso  = 4;
        public const int Rendimento = 5;
        public const int Resgate    = 6;
        public const int Todos      = 7;
        
    }
}
