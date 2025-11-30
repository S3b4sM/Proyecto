using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Datos
    {
        public DataTable dIngresos { get; set; }
        public DataTable dEgresos { get; set; }
        public DataTable DetalleMov { get; set; }
        public DataTable DetallePed { get; set; }
        public decimal SumIngresos { get; set; }
        public decimal SumEgresos { get; set; }
        public decimal Balance { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public decimal PorcentajeEgresos { get; set; }
        public decimal PorcentajeIngresos { get; set; }
        public Datos() { }
    }
}
