using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Duplicador(double cantidad)
        {
            var duplicado = cantidad * 2;
            return Json(duplicado);
        }

        public double DuplicadorComparativo(double cantidad)
        {
            var duplicado = cantidad * 2;
            return duplicado;
        }

        public ActionResult DuplicadorCantidad_CS(double cantidadCS)
        {
            var cantidadDuplicada = DuplicadorComparativo(cantidadCS);
            ViewBag.Resultado = cantidadDuplicada;
            return View("Contact");
        }

        [HttpPost]
        public ContentResult DuplicadorCantidad_Ajax(double cantidadAjax)
        {
            var cantidadDuplicada = DuplicadorComparativo(cantidadAjax);
            return Content(cantidadDuplicada.ToString());
            
        }
    }
}