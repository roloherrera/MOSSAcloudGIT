using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G7.Models
{
    public class CitasObj
    {
        public class Cita
        {
            public int Id { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaHoraInicio { get; set; }
            public DateTime FechaHoraFin { get; set; }
            public string Nombre { get; set; }
        }

    }

    public class RespuestaCitasObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public CitasObj objeto { get; set; }
        public List<CitasObj> lista { get; set; }
    }
}