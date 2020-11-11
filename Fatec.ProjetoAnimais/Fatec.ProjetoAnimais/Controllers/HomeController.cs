using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.ProjetoAnimais.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult IndexUsuario()
        {
            return View();
        }
    }
}