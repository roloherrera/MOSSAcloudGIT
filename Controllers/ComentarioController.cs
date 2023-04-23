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

        [HttpGet]
        public ActionResult ConsultarComentarios(int idPaciente)
        {
            var respuesta = instanciaComentario.ConsultarComentariosUsuario(idPaciente);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        [HttpGet]
        public ActionResult AgregarComentario(int idPaciente)
        {
            ComentarioObj comentario = new ComentarioObj();
            comentario.IdUsuario = idPaciente;

            return View(comentario);
        }

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