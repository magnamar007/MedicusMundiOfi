using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EProyecto
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public float Presupuesto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public string Fechainistrin { get; set; }
        public string Fechainistrfin { get; set; }
    }
}
