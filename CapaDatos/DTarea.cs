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
    public class DTarea
    {
        #region "PATRON SINGLETON"
        public static DTarea _instancia = null;

        private DTarea()
        {

        }

        public static DTarea getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new DTarea();
            }
            return _instancia;
        }
        #endregion

        public bool RegistrarTarea(ETarea oTarea)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_RegistrarTarea", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdUsuario", oTarea.IdUsuario);
                        cmd.Parameters.AddWithValue("@IdProyecto", oTarea.IdProyecto);
                        cmd.Parameters.AddWithValue("@DescripcionTarea", oTarea.DescripcionTarea);
                        cmd.Parameters.AddWithValue("@FechaEntrega", oTarea.FechaEntrega);

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

        public List<ETarea> ObtenerListTareas()
        {
            List<ETarea> rptListaRol = new List<ETarea>();

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand comando = new SqlCommand("usp_ObtenerTareas", con))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rptListaRol.Add(new ETarea()
                                {
                                    Idtarea = Convert.ToInt32(dr["Idtarea"]),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    IdProyecto = Convert.ToInt32(dr["IdProyecto"]),
                                    DescripcionTarea = dr["DescripcionTarea"].ToString(),
                                    FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"].ToString()),
                                    //FechaReserva = Convert.ToDateTime(dr["FechaSolicitado"].ToString()).ToString("yyyy-MM-dd")
                                    Estado = dr["Estado"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                                    oEUsuario = new EUsuario()
                                    {
                                        Nombres = dr["NomPerso"].ToString()
                                    },
                                    oEProyecto = new EProyecto()
                                    {
                                        Nombre = dr["Nombre"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        Presupuesto = float.Parse(dr["Presupuesto"].ToString())
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

        public List<ETarea> ObtenerListTareasId(int IdPer)
        {
            List<ETarea> rptListaRol = new List<ETarea>();

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand comando = new SqlCommand("usp_ObtenerTareasId", con))
                    {
                        comando.Parameters.AddWithValue("@IdUsuario", IdPer);
                        comando.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rptListaRol.Add(new ETarea()
                                {
                                    Idtarea = Convert.ToInt32(dr["Idtarea"]),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    IdProyecto = Convert.ToInt32(dr["IdProyecto"]),
                                    DescripcionTarea = dr["DescripcionTarea"].ToString(),
                                    FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"].ToString()),
                                    //FechaReserva = Convert.ToDateTime(dr["FechaSolicitado"].ToString()).ToString("yyyy-MM-dd")
                                    Estado = dr["Estado"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString()),
                                    oEUsuario = new EUsuario()
                                    {
                                        Nombres = dr["NomPerso"].ToString()
                                    },
                                    oEProyecto = new EProyecto()
                                    {
                                        Nombre = dr["Nombre"].ToString(),
                                        Descripcion = dr["Descripcion"].ToString(),
                                        Presupuesto = float.Parse(dr["Presupuesto"].ToString())
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

