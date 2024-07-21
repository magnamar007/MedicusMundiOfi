using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ETareaEntregada
    {
        public int IdEntregada { get; set; }
        public int Idtarea { get; set; }
        public string Comentario { get; set; }
        public string DocumentoPdf { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public ETarea oETarea { get; set; }
    }
}
