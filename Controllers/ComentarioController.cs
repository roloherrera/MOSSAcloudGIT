using G7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G7.Controllers
{
    public class ComentarioController : Controller
    {
        ComentarioModel instanciaComentario = new ComentarioModel();
        [Filtro]
        [HttpGet]
        public ActionResult ConsultarComentarios(int idPaciente)
        {
            int tipoUsuario = Convert.ToInt32(Session["tipoUsuario"]);
            if (tipoUsuario != 3)
            {
                return View("Unauthorized");
            }
            var respuesta = instanciaComentario.ConsultarComentariosUsuario(idPaciente);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        [Filtro]
        [HttpGet]
        public ActionResult AgregarComentario()
        {
            
            return View();
        }

        [Filtro]
        [HttpPost]
        public ActionResult AgregarComentario(ComentarioObj obj)
        {
          
            var resultado = instanciaComentario.RegistrarComentario(obj);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("ConsultarComentarios", "Comentario", new { idPaciente = obj.IdUsuario });
            else
                return View("Error");
        }
    }
}