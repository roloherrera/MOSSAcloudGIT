using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace G7.Models
{
    public class ComentarioModel
    {
        public RespuestaComentarioObj RegistrarComentario(ComentarioObj comentario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Comentario/GuardarComentario";

                JsonContent contenido = JsonContent.Create(comentario);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaComentarioObj>().Result;
                }
                return null;
            }
        }

        public RespuestaComentarioObj ConsultarComentariosUsuario(int idPaciente)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Comentario/ConsultarComentariosUsuario/" + idPaciente;

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaComentarioObj>().Result;
                }

                RespuestaComentarioObj respuestaError = new RespuestaComentarioObj();
                respuestaError.Codigo = -1;
                respuestaError.Mensaje = "No se pudieron obtener los comentarios";
                return respuestaError;
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