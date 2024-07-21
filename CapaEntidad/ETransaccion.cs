using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ETransaccion
    {
        public int Idtransaccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdProyecto { get; set; }
        public string DescripcionPago { get; set; }
        public DateTime FechaTransa { get; set; }
        public string TipoPago { get; set; }
        public float Monto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public EProyecto oEProyecto { get; set; }

    }
}
