//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FisioAPI.Database
{
    using System;
    
    public partial class Consultar_Citas_Paciente_Result
    {
        public int IdCitas { get; set; }
        public int IdUsuarioFK { get; set; }
        public int IdDoctorFK { get; set; }
        public string Condicion { get; set; }
        public System.DateTime Hora { get; set; }
        public bool status { get; set; }
    }
}
