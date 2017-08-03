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
            System.Threading.Thread.Sleep(2000);
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

        [HttpPost]
        public JsonResult CrearPersona(Persona persona)
        {
            //Utilizaremos una clase base para todas nuestras comunicaciones para establecer un estandar
            var resultado = new BaseRespuesta();

            try
            {
                if (persona.Edad < 18)
                {
                    throw new ApplicationException("La persona no puede ser menor de Edad");
                }
                //codigo para crear persona...
                resultado.Mensaje = "Persona creada correctamente";
                resultado.Ok = true;

            }
            catch(Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
            }
            return Json(resultado);
        }

        public class Persona
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
        }

        public class BaseRespuesta
        {
            public bool Ok { get; set; }
            public string Mensaje { get; set; }
        }

        public PartialViewResult SeccionPrueba()
        {
            var personas = new List<Persona>()
            {
                new Persona() { Nombre="Juan1", Edad=999 },
                new Persona() { Nombre = "Juan2", Edad = 999 },
                new Persona() { Nombre = "Juan3", Edad = 99 },
                new Persona() { Nombre = "Juan4", Edad = 9 },
        
            };
            return PartialView("_Prueba", personas);
        }
    }
}