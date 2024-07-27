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
    public class DBandeja
    {
        #region "PATRON SINGLETON"
        public static DBandeja _instancia = null;

        private DBandeja()
        {

        }

        public static DBandeja getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new DBandeja();
            }
            return _instancia;
        }
        #endregion
        public List<ETarea> ObtenerListTareasId(int IdPer)
        {
            int IdPers = IdPer = 1;
            List<ETarea> rptListaRol = new List<ETarea>();

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand comando = new SqlCommand("usp_ObtenerTareasId", con))
                    {
                        comando.Parameters.AddWithValue("@IdUsuario", IdPers);
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
