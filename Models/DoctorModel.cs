using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace G7.Models
{
    public class DoctorModel
    {
        public RespuestaDoctorObj RegistrarDoctor(DoctorObj doctor)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Doctor/Registrar_Doctor";

                JsonContent contenido = JsonContent.Create(doctor);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaDoctorObj>().Result;
                }
                return null;
            }

        }
        public RespuestaDoctorObj MostrarDoctor(int idDoctor)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Doctor/Mostrar_Doctor?idDoctor=" + idDoctor;

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaDoctorObj>().Result;
                }

                RespuestaDoctorObj respuestaError = new RespuestaDoctorObj();
                respuestaError.Codigo = -1;
                respuestaError.Mensaje = "No se pudo obtener el doctor";
                return respuestaError;
            }
        }

        public RespuestaDoctorObj MostrarDoctores()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Doctor/Mostrar_Doctores";

                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaDoctorObj>().Result;
                }
                return null;
            }
        }

    }
    public class DoctorObj
    {
        public int IdDoctor { get; set; }
        public int IdUsuario { get; set; }
        public UsuarioObj Usuario { get; set; }
    }
    public class RespuestaDoctorObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public DoctorObj objeto { get; set; }
        public List<DoctorObj> lista { get; set; }

    }
}