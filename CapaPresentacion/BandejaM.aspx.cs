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
        public static Respuesta<List<ETarea>> Obtener()
        {
            int IdUsuario = Configuracion.oUsuario.IdUsuario;
            List<ETarea> Lista = NBandeja.getInstance().ObtenerListTareasId(IdUsuario);
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
        [WebMethod]
        public static Respuesta<List<ETarea>> DetalleTarea(int Idtarea)
        {
            //int IdUsuario = Configuracion.oUsuario.IdUsuario;
            List<ETarea> Lista = NBandeja.getInstance().ObtenerListTareasId(Idtarea);
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
        [WebMethod]
        public static Respuesta<ETarea> DetalleTareaID(int Idtarea)
        {
            //int IdUsuario = Configuracion.oUsuario.IdUsuario;
            List<ETarea> Lista = NTarea.getInstance().ObtenerListTareas();
            var item = Lista.FirstOrDefault(x => x.Idtarea == Idtarea);
            //Lista = NUsuario.getInstance().ObtenerUsuarios();
            if (item == null)
            {
                return new Respuesta<ETarea>() { estado = false, valor = "Ocurrio un inconveniente intente mas tarde" };
            }
            else
            {
                return new Respuesta<ETarea>() { estado = true, objeto = item};
            }

        }
    }
}