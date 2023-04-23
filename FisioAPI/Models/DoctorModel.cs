using FisioAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class DoctorModel
    {
        //guardar doctor
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
        //lista de doctores
        public RespuestaDoctorObj Mostrar_Doctores()
        {
            RespuestaDoctorObj respuesta = new RespuestaDoctorObj();

            using (var con = new MOSSAEntities())
            {
                var doctores = from d in con.Doctores
                               join u in con.Usuario on d.IdUsuarioFK equals u.IdUsuario
                               select new DoctorObj
                               {
                                   IdDoctor = d.IdDoctor,
                                   IdUsuario = d.IdUsuarioFK,
                                   Usuario = new UsuarioObj
                                   {
                                       Nombre = u.Nombre,
                                       Apellido1 = u.primerApellido,
                                       Apellido2 = u.segundoApellido,
                                       State = u.state

                                   }
                               };

                respuesta.Codigo = 1;
                respuesta.Mensaje = "Lista de doctores obtenida correctamente";
                respuesta.lista = doctores.ToList();
            }

            return respuesta;
        }
        //ver doctor
        public RespuestaDoctorObj Mostrar_Doctor(int idDoctor)
        {
            RespuestaDoctorObj respuesta = new RespuestaDoctorObj();

            using (var con = new MOSSAEntities())
            {
                var doctor = (from d in con.Doctores
                              join u in con.Usuario on d.IdUsuarioFK equals u.IdUsuario
                              where d.IdDoctor == idDoctor
                              select new DoctorObj
                              {
                                  IdDoctor = d.IdDoctor,
                                  IdUsuario = d.IdUsuarioFK,
                                  Usuario = new UsuarioObj
                                  {
                                      Nombre = u.Nombre,
                                      Apellido1 = u.primerApellido,
                                      Apellido2 = u.segundoApellido,
                                      State = u.state

                                  }
                              }).FirstOrDefault();

                if (doctor != null)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Doctor encontrado correctamente";
                    respuesta.objeto = doctor;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Doctor no encontrado";
                }
            }

            return respuesta;
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
