using System;
using G7.Models;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;


namespace G7.Controllers
{
    public class DoctorController : Controller
    {
        DoctorModel instanciaDoctor = new DoctorModel();

        //Agregar Doctor
        [HttpGet]
        public ActionResult RegistrarDoctor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarDoctor(DoctorObj obj)
        {
            var resultado = instanciaDoctor.RegistrarDoctor(obj);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("MostrarDoctores", "Doctor");
            else
                return View("Error");
        }

        //ver doctor
        [HttpGet]
        public ActionResult MostrarDoctor(int id)
        {
            var respuesta = instanciaDoctor.MostrarDoctor(id);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.objeto);
            else
                return View("Error");
        }

        [HttpGet]
        public ActionResult MostrarDoctores()
        {
            var respuesta = instanciaDoctor.MostrarDoctores();

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

    }
}
