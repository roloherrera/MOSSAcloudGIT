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
    public class ComentarioController : ApiController
    {
        private readonly ComentarioModel _comentarioModel = new ComentarioModel();
        private readonly BitacoraModel _bitacoraModel = new BitacoraModel();

        //Guardar comentario
        [HttpPost]
        [Route("api/Comentario/GuardarComentario")]
        public IHttpActionResult GuardarComentario(ComentarioObj comentario)
        {
            try
            {
                var respuesta = _comentarioModel.Registrar_Comentario(comentario);

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
                _bitacoraModel.Registrar_BitacoraE(comentario.IdUsuario.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                return InternalServerError(new Exception("Se presentó un error inesperado conectando con el API"));
            }
        }

        //Consultar comentarios por usuario
        [HttpGet]
        [Route("api/Comentario/ConsultarComentariosUsuario/{idPaciente}")]
        public IHttpActionResult ConsultarComentariosUsuario(int idPaciente)
        {
            try
            {
                var respuesta = _comentarioModel.Consultar_Comentario_Usuario(idPaciente);

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
