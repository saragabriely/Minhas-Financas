using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class Conta
    {
        [Key]
        [Required]
        public int ID { get; set; }
        
        public string Agencia { get; set; }
        public string ContaBancaria { get; set; }
        public string SaldoEmConta { get; set; }

        public int PessoaID  { get; set; }
        public Pessoa Pessoa { get; set; }

        public int TipoContaID { get; set; }
        public TipoConta TipoConta { get; set; }

        public DateTime DataCadastro          { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }

        public bool flagAtivo { get; set; }
    }
}
