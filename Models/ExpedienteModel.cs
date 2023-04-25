using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace G7.Models
{
    public class ExpedienteModel
    {
        public RespuestaExpedienteObj RegistrarExpediente(ExpedientesObj expediente)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expediente/Registrar_Expediente";

                JsonContent contenido = JsonContent.Create(expediente);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaExpedienteObj>().Result;
                }
                return null;
            }
        }

        public RespuestaExpedienteObj EditarExpediente(ExpedientesObj expediente)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expediente/Editar_Expediente";

                JsonContent contenido = JsonContent.Create(expediente);

                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaExpedienteObj>().Result;
                }
                return null;
            }
        }

        public RespuestaExpedienteObj ConsultarExpedientePaciente(int idPaciente)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expediente/ConsultarExpedientePaciente/" + idPaciente;

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaExpedienteObj>().Result;
                }

                RespuestaExpedienteObj respuestaError = new RespuestaExpedienteObj();
                respuestaError.Codigo = -1;
                respuestaError.Mensaje = "No se pudo obtener el expediente";
                return respuestaError;
            }
        }

        public RespuestaExpedienteObj ConsultarExpedientes()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expediente/ConsultarExpedientes";

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var expedientes = respuesta.Content.ReadAsAsync<List<ExpedientesObj>>().Result;

                    RespuestaExpedienteObj respuestaExpedientes = new RespuestaExpedienteObj();
                    respuestaExpedientes.Codigo = 1;
                    respuestaExpedientes.Mensaje = "Expedientes consultados exitosamente";
                    respuestaExpedientes.lista = expedientes;

                    return respuestaExpedientes;
                }
                else
                {
                    RespuestaExpedienteObj respuestaError = new RespuestaExpedienteObj();
                    respuestaError.Codigo = -1;
                    respuestaError.Mensaje = "No se pudo obtener los expedientes";
                    respuestaError.lista = new List<ExpedientesObj>();
                    return respuestaError;
                }
            }
        }
    }
    public class ExpedientesObj
    {

        public int IdExpediente { get; set; }
        public int IdUsuario { get; set; }
        public int IdDoctor { get; set; }
        public string Padecimiento { get; set; }
        public string Tratamiento { get; set; }

    }
    public class RespuestaExpedienteObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public ExpedientesObj objeto { get; set; }
        public List<ExpedientesObj> lista { get; set; }
    }
}