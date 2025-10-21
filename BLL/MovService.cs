using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MovService
    {
        MovRepository MovRepository = new MovRepository();
        public Movimiento AgregarMov(DateTime fecha, decimal monto, int tipo, int id_user, int id_cat, string razon)
        {
            return MovRepository.Agg(fecha, monto, tipo, id_user, id_cat, razon);
        }
        public DataTable CPI (int id) 
        {
            return MovRepository.CPI(id, 21);
        }
        public DataTable CPE (int id)
        {
            return MovRepository.CPE(id, 22);
        }
        public decimal SumIngresos(int id_user)
        {
            return MovRepository.SumIngresos(id_user, 21);
        }
        public decimal SumEgresos(int id_user)
        {
            return MovRepository.SumEgresos(id_user, 22);
        }
    }
}
