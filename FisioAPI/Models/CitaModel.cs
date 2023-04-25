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

                var resultado = con.Registrar_Cita(citas.Descripcion, citas.FechaHoraInicio, citas.FechaHoraFin, citas.Nombre);

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

                var resultado = con.Editar_Citas(citas.IdCita, citas.Descripcion, citas.FechaHoraInicio, citas.FechaHoraFin, citas.Nombre);

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

        

        
    }
    public class CitasObj
    {
        public int IdCita { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }

    public class RespuestaCitasObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public CitasObj objeto { get; set; }
        public List<CitasObj> lista { get; set; }
    }
}