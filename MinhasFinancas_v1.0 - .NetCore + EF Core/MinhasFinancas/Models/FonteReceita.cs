using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasFinancas.Models
{
    public class FonteReceita
    {
        public int FonteReceita_ID { get; set; }

        public string Descricao { get; set; }

        public bool flagAtivo { get; set; }
    }
}
