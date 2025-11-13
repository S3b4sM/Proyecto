using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Pedidos
    {
        public int id_pedido { get; set; }
        public int id_usuario { get; set; }
        public string descripcion { get; set; }
        public decimal abono { get; set; }
        public decimal precio_total { get; set; }
        public string estado { get; set; }
        public DateTime fecha_pedido { get; set; }
        public DateTime fecha_entrega { get; set; }
    }
}
