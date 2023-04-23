using FisioAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class DoctorModel
    {
        public RespuestaDoctorObj Registrar_Doctor(DoctorObj usuario)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();



                var resultado = con.Registrar_Doctor(usuario.IdUsuario);


                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Doctor Registrado Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción";
                }

                return respuesta;
            }
        }

    }
    public class DoctorObj
    {
        public int IdDoctor { get; set; }
        public int IdUsuario { get; set; }


    }
    public class RespuestaDoctorObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public UsuarioObj objeto { get; set; }
        public List<UsuarioObj> lista { get; set; }

    }
}
