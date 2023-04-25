using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Configuration;

namespace G7.Controllers
{
    public class ExpedientesController : Controller
    {
        ExpedienteModel instanciaExpediente = new ExpedienteModel();

        //ver expedientes
        [Filtro]
        [HttpGet]
        public ActionResult ConsultarExpedientes()
        {
            int tipoUsuario = Convert.ToInt32(Session["tipoUsuario"]);
            if (tipoUsuario == 1)
            {
                return View("Unauthorized");
            }

            var respuesta = instanciaExpediente.ConsultarExpedientes();

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        //ver expediente por paciente
        [Filtro]
        [HttpGet]
        public ActionResult ConsultarExpedientePaciente(int idPaciente)
        {
            int tipoUsuario = Convert.ToInt32(Session["tipoUsuario"]);
            if (tipoUsuario == 1)
            {
                return View("Unauthorized");
            }
            var respuesta = instanciaExpediente.ConsultarExpedientePaciente(idPaciente);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        //añadir expediente
        [Filtro]
        [HttpGet]
        public ActionResult RegistrarExpediente()
        {
            int tipoUsuario = Convert.ToInt32(Session["tipoUsuario"]);
            if (tipoUsuario == 1)
            {
                return View("Unauthorized");
            }
            return View();
        }

        [Filtro]
        [HttpPost]
        public ActionResult RegistrarExpediente(ExpedientesObj obj)
        {
            int tipoUsuario = Convert.ToInt32(Session["tipoUsuario"]);
            if (tipoUsuario == 1)
            {
                return View("Unauthorized");
            }
            var resultado = instanciaExpediente.RegistrarExpediente(obj);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("MostrarExpedientes", "Expediente");
            else
                return View("Error");
        }

        //editar expediente
        [Filtro]
        [HttpPost]
        public ActionResult EditarExpediente(ExpedientesObj expediente)
        {
            int tipoUsuario = Convert.ToInt32(Session["tipoUsuario"]);
            if (tipoUsuario == 1)
            {
                return View("Unauthorized");
            }
            var resultado = instanciaExpediente.EditarExpediente(expediente);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("ConsultarExpedientePaciente", new { idPaciente = expediente.IdExpediente });
            else
                return View("Error");
        }

    }
}
        