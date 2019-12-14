using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class Produtos_Descricoes
    {
        public int ID_EMPRESA { get; set; } 
        public string ID_PRODUTO { get; set; } 
        public int ID_DESCRICAO { get; set; } 
        public string DESCRICAO { get; set; } 
        public string COMPL_DESCRICAO_1 { get; set; } 
        public string COMPL_DESCRICAO_2 { get; set; } 
        public int ID_FILIAL { get; set; }
    }
}