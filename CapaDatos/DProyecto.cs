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
    public class DProyecto
    {
        #region "PATRON SINGLETON"
        public static DProyecto _instancia = null;

        private DProyecto()
        {

        }

        public static DProyecto getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new DProyecto();
            }
            return _instancia;
        }
        #endregion

        public bool RegistrarProyecto(EProyecto oUsuario)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_RegistrarProyecto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //cmd.Parameters.AddWithValue("@IdUsuario", oUsuario.IdUsuario);
                        //cmd.Parameters.AddWithValue("@IdProyecto", oUsuario.IdProyecto);
                        cmd.Parameters.AddWithValue("@Nombre", oUsuario.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", oUsuario.Descripcion);
                        cmd.Parameters.AddWithValue("@FechaIni", oUsuario.FechaIni);
                        cmd.Parameters.AddWithValue("@FechaFin", oUsuario.FechaFin);
                        cmd.Parameters.AddWithValue("@Presupuesto", oUsuario.Presupuesto);

                        SqlParameter outputParam = new SqlParameter("@Resultado", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        respuesta = Convert.ToBoolean(outputParam.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar. Intente más tarde.", ex);
            }

            return respuesta;
        }

        public List<EProyecto> ObtenerProyectos()
        {
            List<EProyecto> rptListaRol = new List<EProyecto>();

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand comando = new SqlCommand("listArea", con))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rptListaRol.Add(new EProyecto()
                                {
                                    IdProyecto = Convert.ToInt32(dr["IdProyecto"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    FechaIni = Convert.ToDateTime(dr["FechaIni"].ToString()),
                                    Fechainistrin = Convert.ToDateTime(dr["FechaIni"].ToString()).ToString("dd/MM/yyyy"),
                                    FechaFin = Convert.ToDateTime(dr["FechaFin"].ToString()),
                                    Fechainistrfin = Convert.ToDateTime(dr["FechaFin"].ToString()).ToString("dd/MM/yyyy"),
                                    Presupuesto = float.Parse(dr["Presupuesto"].ToString()),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
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
