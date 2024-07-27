using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NBandeja
    {
        #region "PATRON SINGLETON"
        public static NBandeja _instancia = null;

        private NBandeja()
        {

        }

        public static NBandeja getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new NBandeja();
            }
            return _instancia;
        }
        #endregion
        public List<ETarea> ObtenerListTareasId(int IdPer)
        {
            return DBandeja.getInstance().ObtenerListTareasId(IdPer);
        }
    }
}
