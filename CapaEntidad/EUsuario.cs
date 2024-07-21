using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EUsuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Clave { get; set; }
        public string Foto { get; set; }
        public int IdArea { get; set; }
        public bool Activo { get; set; }
        public EArea oArea { get; set; }
        public string ImageFull => string.IsNullOrEmpty(Foto)
            ? $"/imagenesU/usuaricon.png"
            : Foto;
    }
}
