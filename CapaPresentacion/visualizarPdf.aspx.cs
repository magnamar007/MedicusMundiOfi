using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class visualizarPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idV = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(idV))
            {
                VerPDf(idV);
            }
            else
            {
                Response.Write("<script>alert('El Archivo no se encontro.'); window.close();</script>");
            }
        }
        public void VerPDf(string id)
        {
            int idb = Convert.ToInt32(id);
            string FilePath = "";
            List<ETareaEntregada> listTareaurl = NTareaEntregada.getInstance().ObtenerListTareaEntregada();

            var items = listTareaurl.FirstOrDefault(x => x.Idtarea == idb);
            if (items != null)
            {
                //FilePath = items.Curriculum;
                FilePath = items.DocumentoPdf;
                string ruta = Server.MapPath(FilePath);
                if (File.Exists(ruta))
                {
                    byte[] FileBuffer = File.ReadAllBytes(ruta);
                    if (FileBuffer != null)
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }
                else
                {
                    Response.Write("<script>alert('El Archivo no se encontro.'); window.close();</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('El elemento con el ID especificado no se encontro.'); window.close();</script>");

            }
        }
    }
}