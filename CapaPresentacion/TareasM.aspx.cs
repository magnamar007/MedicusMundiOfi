using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;


namespace CapaPresentacion
{
    public partial class TareasM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static Respuesta<List<EUsuario>> BuscarUsuario(string buscarporNombre)
        {
            List<EUsuario> lista = NUsuario.getInstance().ObtenerUsuariosZ();

            if (lista != null)
            {
                // Filtrar la lista usando LINQ
                var listaFiltrada = lista.Where(u => u.Nombres.IndexOf(buscarporNombre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                return new Respuesta<List<EUsuario>>()
                {
                    estado = true,
                    objeto = listaFiltrada
                };
            }
            else
            {
                return new Respuesta<List<EUsuario>>()
                {
                    estado = false,
                    objeto = null
                };
            }
        }

        [WebMethod]
        public static Respuesta<List<EProyecto>> BuscarProyecto(string buscar)
        {
            List<EProyecto> Lista = NProyecto.getInstance().ObtenerProyectosZ();

            if (Lista != null)
            {
                var listaFiltrada = Lista.Where(u => u.Nombre.IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                return new Respuesta<List<EProyecto>>() { estado = true, objeto = listaFiltrada };
            }
            else
            {
                return new Respuesta<List<EProyecto>>() { estado = false, objeto = null };
            }
        }

        [WebMethod]
        public static Respuesta<List<ETarea>> ListTareasId(int IdPer)
        {
            List<ETarea> Lista = NTarea.getInstance().ObtenerListTareasId(IdPer);

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
        public static Respuesta<bool> GuardarTarea(ETarea oTarea, string fechaEntrega)
        {
            try
            {
                DateTime entrega = Convert.ToDateTime(fechaEntrega);
                ETarea obj = new ETarea
                {
                    IdUsuario = oTarea.IdUsuario,
                    IdProyecto = oTarea.IdProyecto,
                    DescripcionTarea = oTarea.DescripcionTarea,
                    FechaEntrega = entrega
                };
                bool Respuesta = NTarea.getInstance().RegistrarTarea(obj);
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
        public static Respuesta<bool> ActualizarTarea(ETarea oTarea, string fechaEntrega)
        {
            try
            {
                DateTime entrega = Convert.ToDateTime(fechaEntrega);
                ETarea obj = new ETarea
                {
                    Idtarea = oTarea.Idtarea,
                    IdUsuario = oTarea.IdUsuario,
                    IdProyecto = oTarea.IdProyecto,
                    DescripcionTarea = oTarea.DescripcionTarea,
                    FechaEntrega = entrega
                };
                bool Respuesta = NTarea.getInstance().RegistrarTarea(obj);
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
    }
}