using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class TipoPessoa
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "O tipo pessoa não pode passar de 80 caracteres.")]
        public string Descricao { get; set; }

        public const int PessoaFisica   = 1;
        public const int PessoaJuridica = 2;
        public const int BancoCorretora = 3;
        public const int Todos          = 4;
    }
}
