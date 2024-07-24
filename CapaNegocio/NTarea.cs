using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NTarea
    {
        #region "PATRON SINGLETON"
        public static NTarea _instancia = null;

        private NTarea()
        {

        }

        public static NTarea getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new NTarea();
            }
            return _instancia;
        }
        #endregion

        public bool RegistrarTarea(ETarea oTarea)
        {
            return DTarea.getInstance().RegistrarTarea(oTarea);
        }
        public List<ETarea> ObtenerListTareas()
        {
            return DTarea.getInstance().ObtenerListTareas();
        }
        public List<ETarea> ObtenerListTareasId(int IdPer)
        {
            return DTarea.getInstance().ObtenerListTareasId(IdPer);
        }
    }
}
