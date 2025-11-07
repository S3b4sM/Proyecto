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
        public Movimiento AgregarMov(DateTime fecha, decimal monto, int tipo, int id_user, int id_cat)
        {
            return MovRepository.Agg(fecha, monto, tipo, id_user, id_cat);
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
        public bool Actualizar(Movimiento movimiento)
        {
            return MovRepository.Actualizar(movimiento);
        }
        public bool Eliminar(int id)
        {
            return MovRepository.Eliminar(id);
        }   
        public DataTable MostrarMovimientos(int id_user)
        {
            return MovRepository.MostrarMovimientos(id_user);
        }
        public DataTable DetalleMov(int id_user)
        {
            Datos datos = new Datos();
            datos.DetalleMov = MovRepository.DetalleMov(id_user);
            return datos.DetalleMov;
        }
    }
}
