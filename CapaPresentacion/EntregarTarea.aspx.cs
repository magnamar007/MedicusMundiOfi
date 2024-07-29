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
        [WebMethod]
        public static Respuesta<bool> RegistrarTareaEntregada(ETareaEntregada oETareaEntregada, byte[] pdfBytes)
        {
            try
            {
                var pdfUrl = string.Empty;

                if (pdfUrl != null && pdfUrl.Length > 0)
                {
                    var stream = new MemoryStream(pdfBytes);
                    string folder = "/documentoPdfU/";
                    pdfUrl = Utilidadesj.getInstance().UploadPDFA(stream, folder);
                }

                ETareaEntregada obj = new ETareaEntregada
                {
                    Idtarea = oETareaEntregada.Idtarea,
                    Comentario = oETareaEntregada.Comentario,
                    DocumentoPdf = pdfUrl
                };

                bool Respuesta = NTareaEntregada.getInstance().RegistrarTareaEntregada(obj);
                var respuesta = new Respuesta<bool>
                {
                    estado = Respuesta,
                    valor = Respuesta ? "Se registro correctamente" : "Error al registrar falta pdf"
                };
                return respuesta;
            }
            catch (Exception ex)
            {
                return new Respuesta<bool> { estado = false, valor = "Ocurrió un error: " + ex.Message };
            }
        }
    }
}