using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class CasosAbiertos
    {
        public int idCaso { get; set; }

        public string numeroCaso { get; set;}

        public string nombre { get; set;}

        public DateTime fechaRegistro { get; set; }
    }
    public class RespuestaCasosAbiertos
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public CasosAbiertos objeto { get; set; }
        public List<CasosAbiertos> lista { get; set; }
    }
}