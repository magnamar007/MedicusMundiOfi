using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Services;

namespace CapaPresentacion
{
    public partial class EntregarTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Respuesta<List<ETarea>> DetalleTarea(int idTarea)
        {
            //int IdUsuario = Configuracion.oUsuario.IdUsuario;
            List<ETarea> Lista = NBandeja.getInstance().ObtenerListTareasId(idTarea);
            //Lista = NUsuario.getInstance().ObtenerUsuarios();

            if (Lista != null)
            {
                return new Respuesta<List<ETarea>>() { estado = true, objeto = Lista };
            }
            else
            {
                return new Respuesta<List<ETarea>>() { estado = false, objeto = null };
            }

        }
    }
}