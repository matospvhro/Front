using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class Produtos_Categorias
    {
        public int ID_EMPRESA { get; set; }
        public int ID_CATEGORIA { get; set; }
        public string DESCRICAO { get; set; }
        public int ID_CATEGORIA_SUPERIOR { get; set; }
        public int ID_FILIAL { get; set; }
    }
}