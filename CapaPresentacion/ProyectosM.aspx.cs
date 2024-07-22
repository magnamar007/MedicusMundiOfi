using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ProyectosM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static Respuesta<List<EProyecto>> ObtenerProyectos()
        {
            List<EProyecto> Lista = NProyecto.getInstance().ObtenerProyectosZ();

            if (Lista != null)
            {

                return new Respuesta<List<EProyecto>>() { estado = true, objeto = Lista };
            }
            else
            {
                return new Respuesta<List<EProyecto>>() { estado = false, objeto = null };
            }
        }
        [WebMethod]
        public static Respuesta<bool> GuardarProyect(EProyecto oUsuario)
        {
            try
            {

                EProyecto obj = new EProyecto
                {
                    Nombre = oUsuario.Nombre,
                    Descripcion = oUsuario.Descripcion,
                    FechaIni = oUsuario.FechaIni,
                    FechaFin = oUsuario.FechaFin,
                    Presupuesto = oUsuario.Presupuesto
                };

                bool Respuesta = NProyecto.getInstance().RegistrarProyecto(obj);
                var respuesta = new Respuesta<bool>
                {
                    estado = Respuesta,
                    valor = Respuesta ? "Se registro correctamente" : "Error al registrar ingrese otro correo"
                };
                return respuesta;
            }
            catch (Exception ex)
            {
                return new Respuesta<bool> { estado = false, valor = "Ocurrió un error: " + ex.Message };
            }
        }
        [WebMethod]
        public static Respuesta<bool> ActualizarProyecto(EProyecto oUsuario)
        {
            try
            {
                var imageUrl = string.Empty;
                List<EProyecto> Lista = NProyecto.getInstance().ObtenerProyectosZ();
                var item = Lista.FirstOrDefault(x => x.IdProyecto == oUsuario.IdProyecto);

                if (item == null)
                {
                    return new Respuesta<bool>() { estado = false, valor = "Ocurrio un inconveniente intente mas tarde" };
                }
                
                item.IdProyecto = oUsuario.IdProyecto;
                item.Nombre = oUsuario.Nombre;
                item.Descripcion = oUsuario.Descripcion;
                item.FechaIni = oUsuario.FechaIni;
                item.FechaFin = oUsuario.FechaFin;
                item.Presupuesto = oUsuario.Presupuesto;
                item.Activo = oUsuario.Activo;

                bool Respuesta = NProyecto.getInstance().ActualizarProyecto(item);
                var respuesta = new Respuesta<bool>
                {
                    estado = Respuesta,
                    valor = Respuesta ? "Actualizado correctamente" : "Error al actualizar Proyecto"
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