using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ETarea
    {
        public int Idtarea { get; set; }
        public int IdUsuario { get; set; }
        public int IdProyecto { get; set; }
        public string DescripcionTarea { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public EUsuario oEUsuario { get; set; }
        public EProyecto oEProyecto { get; set; }
    }
}
