using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int Pessoa_ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O tipo pessoa não pode passar de 80 caracteres.", MinimumLength = 10)]
        public string nome { get; set; }

        [StringLength(18, ErrorMessage = "O documento deve ter no máximo 18 caracteres.", MinimumLength = 11)]
        public string documento { get; set; }

        public int TipoPessoaID { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

        public DateTime dataCadastro { get; set; }

        public DateTime dataUltimaAlteracao { get; set; }

        [Required]
        public bool flagCadastroAtivo { get; set; }
        
    }
}
