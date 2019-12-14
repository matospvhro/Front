using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class Produto_Preco
    {
        public int ID_EMPRESA { get; set; }
        public int ID_FILIAL { get; set; }
        public string ID_PRODUTO { get; set; }
        public double PRECO_COMPRA { get; set; }
        public double PRECO_CUSTO { get; set; }
        public double CUSTO_MEDIO { get; set; }
        public double PRECO_VENDA { get; set; }
        public double PRECO_VENDA_ANTERIOR { get; set; }
        public DateTime DATA_ATUALIZACAO_PRECO { get; set; }
        public DateTime PRECO_MERCADO { get; set; }
        public double PRECO_TABELA { get; set; }
        public double VALOR_PAUTA { get; set; }
    }
}