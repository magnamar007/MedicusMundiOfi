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
        public List<ETransaccion> obtenerListaTransacciones()
        {
            List<ETransaccion> rptListaRol = new List<ETransaccion>();

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand comando = new SqlCommand("sp_ObtenerTransacciones", con))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rptListaRol.Add(new ETransaccion()
                                {
                                    Idtransaccion = Convert.ToInt32(dr["Idtransaccion"]),
                                    IdProyecto = Convert.ToInt32(dr["IdProyecto"]),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    DescripcionPago = dr["DescripcionPago"].ToString(),
                                    FechaTransa = Convert.ToDateTime(dr["FechaTransa"].ToString()),
                                    TipoPago = dr["TipoPago"].ToString(),
                                    Monto = float.Parse(dr["Monto"].ToString()),
                                    oEProyecto = new EProyecto()
                                    {
                                        Nombre = dr["Nombre"].ToString()
                                    }
                                });
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                //throw ex;
                throw new Exception("Error al obtener las areas", ex);
            }

            return rptListaRol;
        }
        public List<ETransaccion> obtenerListaTransaccionesId(int idPro)
        {
            List<ETransaccion> rptListaRol = new List<ETransaccion>();

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand comando = new SqlCommand("sp_ObtenerTransaccionesId", con))
                    {
                        comando.Parameters.AddWithValue("@IdProyecto", idPro);
                        comando.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rptListaRol.Add(new ETransaccion()
                                {
                                    Idtransaccion = Convert.ToInt32(dr["Idtransaccion"]),
                                    IdProyecto = Convert.ToInt32(dr["IdProyecto"]),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    DescripcionPago = dr["DescripcionPago"].ToString(),
                                    FechaTransa = Convert.ToDateTime(dr["FechaTransa"].ToString()),
                                    TipoPago = dr["TipoPago"].ToString(),
                                    Monto = float.Parse(dr["Monto"].ToString()),
                                    oEProyecto = new EProyecto()
                                    {
                                        Nombre = dr["Nombre"].ToString()
                                    }
                                });
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                //throw ex;
                throw new Exception("Error al obtener las areas", ex);
            }

            return rptListaRol;
        }
    }
}
