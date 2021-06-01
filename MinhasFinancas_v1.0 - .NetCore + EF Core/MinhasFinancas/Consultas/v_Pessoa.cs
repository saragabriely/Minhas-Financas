using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Consultas
{
    public class v_Pessoa
    {
        public int Pessoa_ID { get; set; }
        public string nome { get; set; }
        public string documento { get; set; }
        public string tipoPessoa { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataUltimaAlteracao { get; set; }
        public string flagCadastroAtivo { get; set; }
    }
}
