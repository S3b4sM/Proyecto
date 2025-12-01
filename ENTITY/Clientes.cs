using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Clientes
    {
        public int documento { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public decimal? contorno_busto { get; set; }
        public decimal? contorno_cintura { get; set; }
        public decimal? contorno_cadera { get; set; }
        public decimal? ancho_espalda { get; set; }
        public decimal? talle_delantero { get; set; }
        public decimal? talle_espalda { get; set; }
        public decimal? largo_brazo { get; set; }
        public decimal? contorno_cuello { get; set; }
        public decimal? contorno_muneca { get; set; }
        public decimal? contorno_brazo_biceps { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime? fecha_ultima_medida { get; set; }
        public int id_user { get; set; }
        public Clientes() { }
    }
}
