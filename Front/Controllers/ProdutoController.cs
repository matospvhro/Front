using Front.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Front.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Lista()
        {
            return View(new Produto().ListaDeProdutos());
        }
    }
}