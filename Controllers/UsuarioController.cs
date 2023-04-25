using G7.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace G7.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioModel instanciaUsuario = new UsuarioModel();

        [Filtro]
        [HttpGet]
        public ActionResult MostrarUsuarios()
        {
            int tipoUsuario = Convert.ToInt32(Session["tipoUsuario"]);
            if (tipoUsuario == 1)
            {
                return View("Unauthorized");
            }
            var respuesta = instanciaUsuario.Consultar_Usuarios_Estado(1);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        [HttpGet]
        public ActionResult RegistrarUsuarios()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarUsuarios(UsuarioObj obj)
        {
            var resultado = instanciaUsuario.RegistrarUsuarios(obj);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("MostrarUsuarios", "Usuario");
            else
                return View("Error");
        }

        [HttpGet]
        public ActionResult PrimerRegistro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PrimerRegistro(UsuarioObj obj)
        {
            try
            {
                if (obj == null)
                {
                    throw new ArgumentNullException(nameof(obj), "El objeto de usuario recibido es nulo.");
                }

                obj.State = true;
                obj.TipoUsuario = 1;
                var resultado = instanciaUsuario.RegistrarUsuarios(obj);

                if (resultado != null && resultado.Codigo == 1)
                {
                    return RedirectToAction("Principal", "Home");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                ViewBag.MensajeError = ex.Message;
                return View("Error");
            }
        }


        [Filtro]
        [HttpGet]
        public ActionResult EditarUsuarios(int id)
        {
            int idusuario = Convert.ToInt32(Session["consecutivo"]);
            int tipoUsuario = Convert.ToInt32(Session["tipoUsuario"]);
           
            if (tipoUsuario == 1 && idusuario != id)
            {
                return View("Unauthorized");
            }
            return View();
        }
        [Filtro]
        [HttpPost]
        public ActionResult EditarUsuarios(UsuarioObj obj)
        {
            var resultado = instanciaUsuario.EditarUsuarios(obj);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("MostrarUsuarios", "Usuario");
            else
                return View("Error");
        }
    }
}