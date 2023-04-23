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

        //ver expediente por paciente
        [HttpGet]
        public ActionResult ConsultarExpedientePaciente(int idPaciente)
        {
            var respuesta = instanciaExpediente.ConsultarExpedientePaciente(idPaciente);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        //añadir expediente
        [HttpGet]
        public ActionResult RegistrarExpediente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult RegistrarExpediente(ExpedientesObj obj)
        {
            var resultado = instanciaExpediente.RegistrarExpediente(obj);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("MostrarExpedientes", "Expediente");
            else
                return View("Error");
        }

        //editar expediente
        [HttpPost]
        public ActionResult EditarExpediente(ExpedientesObj expediente)
        {
            var resultado = instanciaExpediente.EditarExpediente(expediente);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("ConsultarExpedientePaciente", new { idPaciente = expediente.IdExpediente });
            else
                return View("Error");
        }

    }
}
        