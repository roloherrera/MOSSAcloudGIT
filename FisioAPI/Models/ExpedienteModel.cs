using FisioAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class ExpedienteModel
    {
        //Agreagar Expediente
        public RespuestaExpedienteObj Registrar_Expediente(ExpedienteObj expediente)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaExpedienteObj respuesta = new RespuestaExpedienteObj();

                var resultado = con.Registrar_Expediente(expediente.IdUsuario, expediente.IdDoctor, expediente.Padecimiento, expediente.Tratamiento);


                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Se creó el registro exitosamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Se presentó un error inesperado (error al conectar a Base de Datos)";
                }

                return respuesta;
            }
        }
        //Editar Expediente
        public RespuestaExpedienteObj Editar_Expediente(ExpedienteObj expediente)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaExpedienteObj respuesta = new RespuestaExpedienteObj();

                var resultado = con.Editar_Expediente(expediente.IdExpediente, expediente.IdUsuario, expediente.IdDoctor, expediente.Padecimiento, expediente.Tratamiento);


                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Se actualizó el registro exitosamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Se presentó un error inesperado (error al conectar a Base de Datos)";
                }

                return respuesta;
            }
        }
        //Consultar expediente por ID Usuario
        public RespuestaExpedienteObj Consultar_Expediente_Paciente(int IdPaciente)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaExpedienteObj respuesta = new RespuestaExpedienteObj();

                var expedientes = con.Consultar_Expediente_Paciente(IdPaciente).Select(e => new ExpedienteObj()
                {
                    IdExpediente = e.IdExpediente,
                    IdUsuario = e.IdUsuarioFk,
                    IdDoctor = e.IdDoctorFK,
                    Padecimiento = e.Padecimiento,
                    Tratamiento = e.Tratamiento
                }).ToList();



                if (expedientes.Count > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Expedientes encontrados";
                    respuesta.lista = expedientes;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron expedientes";
                }

                return respuesta;
            }

        }

        public RespuestaExpedienteObj Consultar_Expedientes()
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaExpedienteObj respuesta = new RespuestaExpedienteObj();

                var expedientes = con.Expediente.Select(e => new ExpedienteObj()
                {
                    IdExpediente = e.IdExpediente,
                    IdUsuario = e.IdUsuarioFk,
                    IdDoctor = e.IdDoctorFK,
                    Padecimiento = e.Padecimiento,
                    Tratamiento = e.Tratamiento
                }).ToList();

                if (expedientes.Count > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Expedientes encontrados";
                    respuesta.lista = expedientes;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron expedientes";
                }

                return respuesta;
            }
        }

    }

    

    public class ExpedienteObj
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
        public ExpedienteObj objeto { get; set; }
        public List<ExpedienteObj> lista { get; set; }
    }
}