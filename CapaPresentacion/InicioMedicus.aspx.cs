using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class InicioMedicus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Respuesta<EUsuario> ObtenerDetalleUsuario()
        {
            try
            {
                if (Configuracion.oUsuario == null)
                {
                    return new Respuesta<EUsuario>() { estado = false, valor = "error no se encontro usuario" };
                }

                int IdUsuario = Configuracion.oUsuario.IdUsuario;
                var listaUsuarios = NUsuario.getInstance().ObtenerUsuariosZ();
                var usuario = listaUsuarios.FirstOrDefault(x => x.IdUsuario == IdUsuario);

                if (usuario == null)
                {
                    return new Respuesta<EUsuario>() { estado = false, valor = "error" };
                }
                else
                {
                    Configuracion.oUsuario = usuario;

                }

                return new Respuesta<EUsuario>() { estado = true, objeto = usuario };
            }
            catch (Exception )
            {
                // Puedes agregar logging aquí para registrar el error
                return new Respuesta<EUsuario> { estado = false, valor = "error" };
            }
        }
    }
}