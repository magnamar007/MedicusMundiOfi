using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NUsuario
    {
        #region "PATRON SINGLETON"
        private static NUsuario daoEmpleado = null;
        private NUsuario() { }
        public static NUsuario getInstance()
        {
            if (daoEmpleado == null)
            {
                daoEmpleado = new NUsuario();
            }
            return daoEmpleado;
        }
        #endregion

        public List<EArea> ObtenerAreas()
        {
            return DUsuario.getInstance().ObtenerAreas();
        }

        public bool RegistrarUsuario(EUsuario oUsuario)
        {
            return DUsuario.getInstance().RegistrarUsuario(oUsuario);
        }

        public List<EUsuario> ObtenerUsuariosZ()
        {
            return DUsuario.getInstance().ObtenerUsuariosZ();
        }
        public bool ActualizarUsuario(EUsuario oUsuario)
        {
            return DUsuario.getInstance().ActualizarUsuario(oUsuario);
        }
        public int LoginUsuarioA(string Correo, string Clave)
        {
            return DUsuario.getInstance().LoginUsuarioA(Correo, Clave);
        }
    }
}
