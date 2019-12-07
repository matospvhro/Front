using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class Produto_Estoque
    {
        public int ID_EMPRESA { get; set; }   
        public int ID_FILIAL { get; set; }   
        public string ID_PRODUTO { get; set; }   
        public string ID_LOTE { get; set; }   
        public DateTime DATA_FABRICACAO { get; set; }   
        public DateTime DATA_VALIDADE { get; set; }   
        public double ESTOQUE_INTEIRO { get; set; }   
        public double ESTOQUE_FRACAO { get; set; }   
        public int ID_GRUPO_PRODUTOS { get; set; }   
        public int ID_SUB_GRUPO_PRODUTOS { get; set; }   
        public int ID_GRADE_PRODUTOS { get; set; }   
        public int ID_LINHA_GRADE { get; set; }   
        public int ID_COLUNA_GRADE { get; set; }   
        public DateTime DATA_ATUALIZACAO { get; set; }   
        public string CHAVE { get; set; }   
        public string REGISTRO_MS { get; set; }
    }
}