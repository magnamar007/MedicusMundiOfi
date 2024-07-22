using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NProyecto
    {
        #region "PATRON SINGLETON"
        private static NProyecto daoProyecto = null;
        private NProyecto() { }
        public static NProyecto getInstance()
        {
            if (daoProyecto == null)
            {
                daoProyecto = new NProyecto();
            }
            return daoProyecto;
        }
        #endregion

        public bool RegistrarProyecto(EProyecto oUsuario)
        {
            return DProyecto.getInstance().RegistrarProyecto(oUsuario);
        }
        public List<EProyecto> ObtenerProyectosZ()
        {
            return DProyecto.getInstance().ObtenerProyectosZ();
        }
        public bool ActualizarProyecto(EProyecto oUsuario)
        {
            return DProyecto.getInstance().ActualizarProyecto(oUsuario);
        }
    }
}
