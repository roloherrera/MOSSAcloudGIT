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
    public class ExpedienteController : ApiController
    {
        private readonly ExpedienteModel _expedienteModel = new ExpedienteModel();
        private readonly BitacoraModel _bitacoraModel = new BitacoraModel();

        // Agrega un expediente
        [HttpPost]
        [Route("api/Expediente/Registrar_Expediente")]
        public IHttpActionResult RegistrarExpediente(ExpedienteObj expediente)
        {
            try
            {
                var respuesta = _expedienteModel.Registrar_Expediente(expediente);

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
                _bitacoraModel.Registrar_BitacoraE(expediente.IdUsuario.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                return InternalServerError(new Exception("Se presentó un error inesperado conectando con el API"));
            }
        }

        // Edita un expediente
        [HttpPut]
        [Route("api/Expediente/Editar_Expediente")]
        public IHttpActionResult EditarExpediente(ExpedienteObj expediente)
        {
            try
            {
                var respuesta = _expedienteModel.Editar_Expediente(expediente);

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
                _bitacoraModel.Registrar_BitacoraE(expediente.IdUsuario.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                return InternalServerError(new Exception("Se presentó un error inesperado conectando con el API"));
            }
        }

        // Consulta los expedientes de un paciente por su ID
        [HttpGet]
        [Route("api/Expediente/ConsultarExpedientePaciente/{idPaciente}")]
        public IHttpActionResult ConsultarExpedientePaciente(int idPaciente)
        {
            try
            {
                var respuesta = _expedienteModel.Consultar_Expediente_Paciente(idPaciente);

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
                _bitacoraModel.Registrar_BitacoraE(idPaciente.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                return InternalServerError(new Exception("Se presentó un error inesperado conectando con el API"));
            }
        }
    }
}
    
