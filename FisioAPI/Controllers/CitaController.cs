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
    public class CitaController : ApiController
    {
        private readonly CitaModel instanciaCita = new CitaModel();
        private readonly BitacoraModel instanciaBitacora = new BitacoraModel();

        // Registrar cita
        [HttpPost]
        [Route("api/Cita/Registrar_Cita")]
        public IHttpActionResult RegistrarCita(CitasObj citas)
        {
            try
            {
                var respuesta = instanciaCita.Registrar_Cita(citas);

                if (respuesta.Codigo == 1)
                {
                    return Ok(respuesta);
                }
                else
                {
                    return BadRequest(respuesta.Mensaje);
                }
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_BitacoraE(citas.IdUsuario.ToString(), ex, MethodBase.GetCurrentMethod().Name);
                return InternalServerError(ex);
            }
        }

        // Editar cita
        [HttpPut]
        [Route("api/Cita/Editar_Citas")]
        public IHttpActionResult EditarCitas(CitasObj citas)
        {
            try
            {
                var respuesta = instanciaCita.Editar_Citas(citas);

                if (respuesta.Codigo == 1)
                {
                    return Ok(respuesta);
                }
                else
                {
                    return BadRequest(respuesta.Mensaje);
                }
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_BitacoraE(citas.IdUsuario.ToString(), ex, MethodBase.GetCurrentMethod().Name);
                return InternalServerError(ex);
            }
        }

        // Consultar cita por doctor
        [HttpGet]
        [Route("api/Cita/Consultar_Citas_Doctor/{IdDoctor}")]
        public IHttpActionResult ConsultarCitasDoctor(int IdDoctor)
        {
            try
            {
                var respuesta = instanciaCita.Consultar_Citas_Doctor(IdDoctor);

                if (respuesta.Codigo == 1)
                {
                    return Ok(respuesta);
                }
                else
                {
                    return BadRequest(respuesta.Mensaje);
                }
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_BitacoraE(IdDoctor.ToString(), ex, MethodBase.GetCurrentMethod().Name);
                return InternalServerError(ex);
            }
        }

        // Consultar cita por paciente
        [HttpGet]
        [Route("api/Cita/Consultar_Citas_Paciente/{IdPaciente}")]
        public IHttpActionResult ConsultarCitasPaciente(int IdPaciente)
        {
            try
            {
                var respuesta = instanciaCita.Consultar_Citas_Paciente(IdPaciente);

                if (respuesta.Codigo == 1)
                {
                    return Ok(respuesta);
                }
                else
                {
                    return BadRequest(respuesta.Mensaje);
                }
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_BitacoraE(IdPaciente.ToString(), ex, MethodBase.GetCurrentMethod().Name);
                return InternalServerError(ex);
            }
        }
    }
}

