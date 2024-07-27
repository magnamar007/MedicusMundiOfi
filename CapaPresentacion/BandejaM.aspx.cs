using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class BandejaM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static Respuesta<List<ETarea>> Obtner(int IdPEr)
        {
            List<ETarea> Lista = NBandeja.getInstance().ObtenerListTareasId(IdPEr);
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