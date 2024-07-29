using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NTareaEntregada
    {
        #region "PATRON SINGLETON"
        public static NTareaEntregada _instancia = null;

        private NTareaEntregada()
        {

        }

        public static NTareaEntregada getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new NTareaEntregada();
            }
            return _instancia;
        }
        #endregion
        public bool RegistrarTareaEntregada(ETareaEntregada oETareaEntregada)
        {
            return DTareaEntregada.getInstance().RegistrarTareaEntregada(oETareaEntregada);
        }
    }
}
