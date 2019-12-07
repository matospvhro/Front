using Front.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class Produto
    {
        public int ID_EMPRESA { get; set; }
        public int ID_PRODUTO { get; set; }
        public int ID_FABRICANTE_FORNECEDOR { get; set; }
        public string CODIGO_BARRAS { get; set; }
        public string CODIGO_FABRICANTE { get; set; }
        public int ID_GRUPO_PRODUTOS { get; set; }
        public int ID_SUB_GRUPO_PRODUTOS { get; set; }
        public int CLASSIFICACAO { get; set; }
        public int TIPO_UNIDADE { get; set; }
        public int QUANT_UNITARIA { get; set; }
        public string UNIDADE { get; set; }
        public int FRACAO { get; set; }
        public int COMPOSTO { get; set; }
        public string USO_CONTINUO { get; set; }
        public int OBSERVACOES { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int SITUACAO { get; set; }
        public int ID_GRADE_PRODUTOS { get; set; }
        public int CAMPOS_USUARIO { get; set; }
        public int ID_FILIAL { get; set; }
        public DateTime DATA_CADASTRO { get; set; }
        public string DESCRICAO_WEB { get; set; }
        public bool ENVIA_WEB { get; set; }
        public double PESO_BRUTO { get; set; }
        public double PESO_LIQUIDO { get; set; }
        public int ID_FLUXO { get; set; }
        public int TEMPO_EXECUCAO { get; set; }
        public int LIMITE_EXECUCAO_SIMULTANEA { get; set; }
        public int QUANT_MIN_VENDA { get; set; }
        public Produtos_Descricoes Produtos_Descricoes { get; set; }
        public IList<Produto> ListaDeProdutos()
        {
            return new AcessoFB().ListaProdutos();
        }
    }
}