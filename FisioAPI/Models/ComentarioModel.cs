using FisioAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class ComentarioModel
    {
        //Guardar comentario
        public RespuestaComentarioObj Registrar_Comentario(ComentarioObj comentario)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaComentarioObj respuesta = new RespuestaComentarioObj();

                var resultado = con.Registrar_Comentario(comentario.IdUsuario, comentario.Comentario);

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Se creó el comentario exitosamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Se presentó un error inesperado (error al conectar a Base de Datos)";
                }

                return respuesta;
            }
        }

        //Consultar comentarios por paciente
        public RespuestaComentarioObj Consultar_Comentario_Usuario(int idPaciente)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaComentarioObj respuesta = new RespuestaComentarioObj();

                var comentarios = con.Consultar_Comentario_Usuario(idPaciente);

                if (comentarios != null)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Consulta realizada exitosamente";
                    respuesta.lista = comentarios.Select(c => new ComentarioObj
                    {
                        IdComentario = c.idComentarios,
                        IdUsuario = c.idUsuariosFk,
                        Comentario = c.textoComentario
                    }).ToList();
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Se presentó un error inesperado (error al conectar a Base de Datos)";
                }

                return respuesta;
            }
        }
    }
    public class ComentarioObj
    {
        public int IdComentario { get; set; }
        public int IdUsuario { get; set; }
        public String Comentario { get; set; }
        
    }

    public class RespuestaComentarioObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public ComentarioObj objeto { get; set; }
        public List<ComentarioObj> lista { get; set; }
    }
}