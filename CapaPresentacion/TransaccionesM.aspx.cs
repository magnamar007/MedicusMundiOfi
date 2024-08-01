using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace CapaPresentacion
{
    public partial class TransaccionesM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static Respuesta<bool> GuardarTransaccion(ETransaccion oTransaccion, string fechaTransa)
        {
            try
            {
                DateTime transaccion = Convert.ToDateTime(fechaTransa);
                ETransaccion obj = new ETransaccion
                {
                    IdUsuario = oTransaccion.IdUsuario,
                    IdProyecto = oTransaccion.IdProyecto,
                    DescripcionPago = oTransaccion.DescripcionPago,
                    FechaTransa = transaccion,
                    TipoPago = oTransaccion.TipoPago,
                    Monto = oTransaccion.Monto
                };
                bool Respuesta = NTransaccion.getInstance().RegistrarTransaccion(obj);
                var respuesta = new Respuesta<bool>
                {
                    estado = Respuesta,
                    valor = Respuesta ? "Se registro correctamente" : "Error al registrar intente mas tarde"
                };
                return respuesta;
            }
            catch (Exception ex)
            {
                return new Respuesta<bool> { estado = false, valor = "Ocurrió un error: " + ex.Message };
            }
        }
        [WebMethod]
        public static Respuesta<List<ETransaccion>> ListTransaccionId(int idPro)
        {
            List<ETransaccion> Lista = NTransaccion.getInstance().ObtenerListTransaccionesId(idPro);

            if (Lista != null)
            {
                return new Respuesta<List<ETransaccion>>() { estado = true, objeto = Lista };
            }
            else
            {
                return new Respuesta<List<ETransaccion>>() { estado = false, objeto = null };
            }
        }
    }
}