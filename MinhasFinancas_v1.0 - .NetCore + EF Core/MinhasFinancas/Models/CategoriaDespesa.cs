using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class CategoriaDespesa
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "A categoria tem o tamanho máximo de 30 caracteres.")]
        public string Descricao { get; set; }

        public string PorcentagemIdeal { get; set; }


        public const int Essencial = 1;
        public const int Estudos   = 2;
        public const int Metas     = 3;
        public const int Outros    = 4;

    }
}
