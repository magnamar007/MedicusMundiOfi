using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class IniciodeSesionM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control","no-store");
        }
        [WebMethod]
        public static Respuesta<int> Iniciar(string correo, string clave)
        {
            try
            {
                int IdUsuario = NUsuario.getInstance().LoginUsuarioA(correo, clave);

                if (IdUsuario != 0)
                {
                    Configuracion.oUsuario = new EUsuario() { IdUsuario = IdUsuario };
                    return new Respuesta<int>() { estado = true, valor = IdUsuario.ToString() };
                }
                else
                {
                    return new Respuesta<int>() { estado = false };
                }
            }
            catch (Exception ex)
            {
                return new Respuesta<int>() { estado = false, valor = "Ocurrió un error: " + ex.Message };
            }

        }
        //public static Respuesta<int> Iniciar(string Usuario, int IdUsuario)
        //{
        //    try
        //    {
        //        // Aquí asumimos que IdUsuario se proporciona directamente sin necesidad de verificación adicional
        //        if (IdUsuario != 0)
        //        {
        //            Configuracion.oUsuario = new EUsuario() { IdUsuario = IdUsuario };
        //            return new Respuesta<int>() { estado = true, valor = IdUsuario.ToString() };
        //        }
        //        else
        //        {
        //            return new Respuesta<int>() { estado = false };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Respuesta<int>() { estado = false, valor = "Ocurrió un error: " + ex.Message };
        //    }
        //}

    }
}