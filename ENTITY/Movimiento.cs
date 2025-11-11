using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Movimiento
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public string razon { get; set; }
        public int tipo { get; set; }
        public int id_user { get; set; }
        public int id_categoria { get; set; }
        public string descripcion { get; set; }
    }
}
