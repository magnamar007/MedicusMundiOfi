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
        public static Respuesta<bool> GuardarProyect(EProyecto oProyecto, string fechainicio, string fechafin)
        {
            try
            {

                DateTime inicio = Convert.ToDateTime(fechainicio);
                DateTime fin = Convert.ToDateTime(fechafin);
                EProyecto obj = new EProyecto
                {
                    Nombre = oProyecto.Nombre,
                    Descripcion = oProyecto.Descripcion,
                    FechaIni = inicio,
                    FechaFin = fin,
                    Presupuesto = oProyecto.Presupuesto
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
        public static Respuesta<bool> ActualizarProyecto(EProyecto oProyecto, string fechainicio, string fechafin)
        {
            try
            {
                DateTime inicio = Convert.ToDateTime(fechainicio);
                DateTime fin = Convert.ToDateTime(fechafin);
                List<EProyecto> Lista = NProyecto.getInstance().ObtenerProyectosZ();
                var item = Lista.FirstOrDefault(x => x.IdProyecto == oProyecto.IdProyecto);

                if (item == null)
                {
                    return new Respuesta<bool>() { estado = false, valor = "Ocurrio un inconveniente intente mas tarde" };
                }
                
                item.IdProyecto = oProyecto.IdProyecto;
                item.Nombre = oProyecto.Nombre;
                item.Descripcion = oProyecto.Descripcion;
                item.FechaIni = inicio;
                item.FechaFin = fin;
                item.Presupuesto = oProyecto.Presupuesto;
                item.Activo = oProyecto.Activo;

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