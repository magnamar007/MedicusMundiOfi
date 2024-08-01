using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class DTransaccion
    {
        #region "PATRON SINGLETON"
        public static DTransaccion _instancia = null;

        private DTransaccion()
        {

        }

        public static DTransaccion getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new DTransaccion();
            }
            return _instancia;
        }
        #endregion
        public bool RegistrarTransaccion(ETransaccion oTransaccion)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarTransaccion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdUsuario", oTransaccion.IdUsuario);
                        cmd.Parameters.AddWithValue("@IdProyecto", oTransaccion.IdProyecto);
                        cmd.Parameters.AddWithValue("@DescripcionPago", oTransaccion.DescripcionPago);
                        cmd.Parameters.AddWithValue("@FechaTransa", oTransaccion.FechaTransa);
                        cmd.Parameters.AddWithValue("@TipoPago", oTransaccion.TipoPago);
                        cmd.Parameters.AddWithValue("@Monto", oTransaccion.Monto);

                        con.Open();
                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0) respuesta = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar. Intente más tarde.", ex);
            }

            return respuesta;
        }
    }
}
