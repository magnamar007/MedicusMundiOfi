using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Services;

namespace CapaPresentacion
{
    public partial class PersonalM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Respuesta<List<EArea>> ObtenerAreas()
        {
            List<EArea> Lista = NUsuario.getInstance().ObtenerAreas();

            if (Lista != null)
            {

                return new Respuesta<List<EArea>>() { estado = true, objeto = Lista };
            }
            else
            {
                return new Respuesta<List<EArea>>() { estado = false, objeto = null };
            }
        }

        [WebMethod]
        public static Respuesta<List<EUsuario>> ObtenerUsuario()
        {
            List<EUsuario> Lista = NUsuario.getInstance().ObtenerUsuariosZ();

            if (Lista != null)
            {
                return new Respuesta<List<EUsuario>>() { estado = true, objeto = Lista };
            }
            else
            {
                return new Respuesta<List<EUsuario>>() { estado = false, objeto = null };
            }
        }

        [WebMethod]
        public static Respuesta<bool> GuardarUsua(EUsuario oUsuario, byte[] imageBytes)
        {
            try
            {
                var imageUrl = string.Empty;

                if (imageBytes != null && imageBytes.Length > 0)
                {
                    var stream = new MemoryStream(imageBytes);
                    string folder = "/imagenesU/";
                    imageUrl = Utilidadesj.getInstance().UploadPhotoA(stream, folder);
                }

                EUsuario obj = new EUsuario
                {
                    Nombres = oUsuario.Nombres,
                    Apellidos = oUsuario.Apellidos,
                    Correo = oUsuario.Correo,
                    Celular = oUsuario.Celular,
                    Clave = oUsuario.Clave,
                    Foto = imageUrl,
                    IdArea = oUsuario.IdArea
                };

                bool Respuesta = NUsuario.getInstance().RegistrarUsuario(obj);
                var respuesta = new Respuesta<bool>
                {
                    estado = Respuesta,
                    valor = Respuesta ? "Se registro correctamente" : "Error al registrar ingrese otro correo"
                };
                return respuesta;
            }
            catch (Exception ex)
            {
                return new Respuesta<bool> { estado = false, valor = "Ocurrió un error: " + ex.Message };
            }
        }
        [WebMethod]
        public static Respuesta<bool> ActualizarUsua(EUsuario oUsuario, byte[] imageBytes)
        {
            try
            {
                var imageUrl = string.Empty;
                List<EUsuario> Lista = NUsuario.getInstance().ObtenerUsuariosZ();
                var item = Lista.FirstOrDefault(x => x.IdUsuario == oUsuario.IdUsuario);

                if (item == null)
                {
                    return new Respuesta<bool>() { estado = false, valor = "Ocurrio un inconveniente intente mas tarde"};
                }
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    var stream = new MemoryStream(imageBytes);
                    string folder = "/imagenesU/";
                    imageUrl = Utilidadesj.getInstance().UploadPhotoA(stream, folder);
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        if (!string.IsNullOrEmpty(item.Foto))
                        {
                            File.Delete(HttpContext.Current.Server.MapPath(item.Foto));
                        }
                    }
                    else
                    {
                        // Si no se pudo guardar la nueva imagen, mantener la URL de la imagen anterior
                        imageUrl = item.Foto;
                    }
                }
                else
                {
                    imageUrl = item.Foto;
                }

                item.IdUsuario = oUsuario.IdUsuario;
                item.Nombres = oUsuario.Nombres;
                item.Apellidos = oUsuario.Apellidos;
                item.Correo = oUsuario.Correo;
                item.Celular = oUsuario.Celular;
                item.Clave = oUsuario.Clave;
                item.Foto = imageUrl;
                item.IdArea = oUsuario.IdArea;
                item.Activo = oUsuario.Activo;

                bool Respuesta = NUsuario.getInstance().ActualizarUsuario(item);
                var respuesta = new Respuesta<bool>
                {
                    estado = Respuesta,
                    valor = Respuesta ? "Actualizado correctamente" : "Error al actualizar el Correo ya Existe"
                };
                return respuesta;
            }
            catch (Exception ex)
            {
                return new Respuesta<bool> { estado = false, valor = "Ocurrió un error: " + ex.Message };
            }
        }
    }
}