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
    
    public partial class Consultar_Usuarios_Estado_Result
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string cedula { get; set; }
        public int telefono { get; set; }
        public string Email { get; set; }
        public string genero { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public int idTipoUsuarioFk { get; set; }
        public bool state { get; set; }
    }
}
