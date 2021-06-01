using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class Despesa
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

        [Required]
        public string ValorAPagar { get; set; }
        public string ValorPago   { get; set; }

        public int CategoriaDespesaID { get; set; }
        public CategoriaDespesa CategoriaDespesa { get; set; }

        public int FormaPagamentoID { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        public int StatusDespesaID { get; set; }
        public StatusDespesa StatusDespesa { get; set; }

        public int PessoaID { get; set; }
        public Pessoa Pessoa { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }

    }
}
