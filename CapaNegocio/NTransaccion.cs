using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NTransaccion
    {
        #region "PATRON SINGLETON"
        public static NTransaccion _instancia = null;

        private NTransaccion()
        {

        }

        public static NTransaccion getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new NTransaccion();
            }
            return _instancia;
        }
        #endregion
        public bool RegistrarTransaccion(ETransaccion oTransaccion)
        {
            return DTransaccion.getInstance().RegistrarTransaccion(oTransaccion);
        }
        public List<ETransaccion> ObtenerListTransacciones()
        {
            return DTransaccion.getInstance().obtenerListaTransacciones();
        }
        public List<ETransaccion> ObtenerListTransaccionesId(int idPro)
        {
            return DTransaccion.getInstance().obtenerListaTransaccionesId(idPro);
        }
    }
}
