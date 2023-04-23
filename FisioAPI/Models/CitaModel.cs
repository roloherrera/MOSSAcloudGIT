using FisioAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class CitaModel
    {
        //registrar cita
        public RespuestaCitasObj Registrar_Cita(CitasObj citas)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                var resultado = con.Registrar_Cita(citas.IdUsuario, citas.IdDoctor, citas.Condicion, citas.Hora, citas.Hora);

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Cita Registrada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción (error al conectar a Base de Datos)";
                }

                return respuesta;
            }
        }

        //editar cita
        public RespuestaCitasObj Editar_Citas(CitasObj citas)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                var resultado = con.Editar_Citas(citas.IdCita, citas.IdUsuario, citas.IdDoctor, citas.Condicion, citas.Hora, citas.Hora, citas.Status);

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Cita Editado Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción (error al conectar a Base de Datos)";
                }

                return respuesta;
            }
        }

        //consultar cita por doctor
        public RespuestaCitasObj Consultar_Citas_Doctor(int IdDoctor)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                var citas = con.Consultar_Citas_Doctor(IdDoctor);

                if (citas != null)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Citas obtenidas correctamente";
                    respuesta.lista = citas.Select(c => new CitasObj
                    {
                        IdCita = c.IdCitas,
                        IdUsuario = c.IdUsuarioFK,
                        IdDoctor = c.IdDoctorFK,
                        Condicion = c.Condicion,
                        Hora = c.Hora,
                        Status = c.status
                    }).ToList();
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron citas para el doctor especificado";
                    respuesta.lista = new List<CitasObj>();
                }

                return respuesta;
            }
        }

        //consultar cita por paciente
        public RespuestaCitasObj Consultar_Citas_Paciente(int IdPaciente)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                var citas = con.Consultar_Citas_Paciente(IdPaciente);

                if (citas != null)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Citas obtenidas correctamente";
                    respuesta.lista = citas.Select(c => new CitasObj
                    {
                        IdCita = c.IdCitas,
                        IdUsuario = c.IdUsuarioFK,
                        IdDoctor = c.IdDoctorFK,
                        Condicion = c.Condicion,
                        Hora = c.Hora,
                        Status = c.status
                    }).ToList();
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron citas para el paciente especificado";
                    respuesta.lista = new List<CitasObj>();
                }

                return respuesta;
            }
        }
    }
    public class CitasObj
    {
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public int IdDoctor { get; set; }
        public string Condicion { get; set; }
        public DateTime Hora { get; set; }
        public bool Status { get; set; }
    }

    public class RespuestaCitasObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public CitasObj objeto { get; set; }
        public List<CitasObj> lista { get; set; }
    }
}