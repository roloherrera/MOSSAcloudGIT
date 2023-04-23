using FisioAPI.Database;
using FisioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Web.Http;

namespace FisioAPI.Controllers
{
    public class DoctorController : ApiController
    {
        DoctorModel instanciaDoctor = new DoctorModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();

        
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Doctor/Registrar_Doctor")]
        public RespuestaDoctorObj Registrar_Doctor(DoctorObj Doctor)
        {
            try
            {
                return instanciaDoctor.Registrar_Doctor(Doctor);
            }
            catch (Exception ex)
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Doctor/Mostrar_Doctor/{idDoctor}")]
        public RespuestaDoctorObj Mostrar_Doctor(int idDoctor)
        {
            var correoToken = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                return instanciaDoctor.Mostrar_Doctor(idDoctor);

            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_BitacoraE(correoToken, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado conectando con el API";
                return respuesta;
            }
            
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Doctor/Mostrar_Doctores")]
        public RespuestaDoctorObj Mostrar_Doctores()
        {
            var correoToken = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                return instanciaDoctor.Mostrar_Doctores();

            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_BitacoraE(correoToken, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado conectando con el API";
                return respuesta;
            }

        }


    }
}
    
