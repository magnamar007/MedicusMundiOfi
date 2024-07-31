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
    public class DTareaEntregada
    {
        #region "PATRON SINGLETON"
        public static DTareaEntregada _instancia = null;

        private DTareaEntregada()
        {

        }

        public static DTareaEntregada getInstance()
        {
            if (_instancia == null)
            {
                _instancia = new DTareaEntregada();
            }
            return _instancia;
        }
        #endregion
        public bool RegistrarTareaEntregada(ETareaEntregada oETareaEntregada)
        {
            bool respuesta = false;

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EntregarTarea", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Idtarea", oETareaEntregada.Idtarea);
                        cmd.Parameters.AddWithValue("@Comentario", oETareaEntregada.Comentario);
                        cmd.Parameters.AddWithValue("@DocumentoPdf", oETareaEntregada.DocumentoPdf);
                        //cmd.Parameters.AddWithValue("@PdfFull", oTarea.DescripcionTarea);

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
        public List<ETareaEntregada> ObtenerListTareaEntregada()
        {
            List<ETareaEntregada> rptListaRol = new List<ETareaEntregada>();

            try
            {
                using (SqlConnection con = ConexionBD.getInstance().ConexionDB())
                {
                    using (SqlCommand comando = new SqlCommand("usp_ObtenerTareasEntregadas", con))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        using (SqlDataReader dr = comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rptListaRol.Add(new ETareaEntregada()
                                {
                                    IdEntregada = Convert.ToInt32(dr["IdEntregada"]),
                                    Idtarea = Convert.ToInt32(dr["Idtarea"]),
                                    Comentario = dr["Comentario"].ToString(),
                                    DocumentoPdf = dr["DocumentoPdf"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                    oETarea = new ETarea
                                    {
                                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                        IdProyecto = Convert.ToInt32(dr["IdProyecto"]),
                                        DescripcionTarea = dr["DescripcionTarea"].ToString(),
                                        FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"].ToString()),
                                        Estado = dr["Estado"].ToString(),
                                        Activo = Convert.ToBoolean(dr["Activo"])
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
