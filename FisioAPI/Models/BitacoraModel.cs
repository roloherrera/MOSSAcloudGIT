using System;
using FisioAPI.Database;

namespace FisioAPI.Models
{
    public class BitacoraModel
    {
        public void Registrar_BitacoraE(string email, Exception ex, string origen)
        {
            using (var con = new MOSSAEntities())
            {
                con.Registrar_BitacoraE(email, DateTime.Now, ex.HResult, ex.Message, origen);

            }
        }
        public void Registrar_BitacoraA(string email, Exception ex, string origen)
        {
            using (var con = new MOSSAEntities())
            {
                con.Registrar_BitacoraA(email, DateTime.Now, ex.Message, origen);

            }
        }
    }
}