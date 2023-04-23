using FisioAPI.Database;
using FisioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace FisioAPI.Controllers
{
    public class DoctorController : ApiController
    {
        DoctorModel instanciaDoctor = new DoctorModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();

        ////Revisa que el Doctor exista en el sistema 
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




       
    }
}
    
