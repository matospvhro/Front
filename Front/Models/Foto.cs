using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front.Models
{
    public class Foto
    {
        public int ID_EMPRESA { get; set; }
        public int ID_FILIAL { get; set; }
        public int ID_GRUPO_PRODUTOS { get; set; }
        public int ID_SUB_GRUPO_PRODUTOS { get; set; }
        public string ID_PRODUTO { get; set; }
        public int ID_CLIENTE { get; set; }
        public int ID_USUARIO { get; set; }
        public string ID_CODIGO_MOVIMENTACAO { get; set; }
        public byte[] FOTOGRAFIA { get; set; }
    }
}