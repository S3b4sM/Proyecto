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
        PedidosRepository pedidos = new PedidosRepository();
        public Movimiento AgregarMov(DateTime fecha, decimal monto, int tipo, int id_user, int id_cat, string desc)
        {
            return MovRepository.Agg(fecha, monto, tipo, id_user, id_cat, desc);
        }
        public DataTable CPI (int id) 
        {
            return MovRepository.CPI(id, 1);
        }
        public DataTable CPE (int id)
        {
            return MovRepository.CPE(id, 2);
        }
        public decimal SumIngresos(int id_user)
        {
            return MovRepository.SumIngresos(id_user, 1);
        }
        public decimal SumEgresos(int id_user)
        {
            return MovRepository.SumEgresos(id_user, 2);
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
        public decimal IngresosMensuales(int id_user)
        {
            return MovRepository.IngresosMes(id_user);
        }
        public Datos ObtenerDatos(int userId)
        {
            Datos data = new Datos();
            DateTime hoy = DateTime.Now;
            DateTime inicioMesActual = new DateTime(hoy.Year, hoy.Month, 1);
            DateTime finMesActual = hoy;
            DateTime inicioMesPasado = inicioMesActual.AddMonths(-1);
            DateTime finMesPasado = finMesActual.AddMonths(-1);
            decimal ingresosActuales = MovRepository.SumaFecha(userId, 1, inicioMesActual, finMesActual);
            decimal egresosActuales = MovRepository.SumaFecha(userId, 2, inicioMesActual, finMesActual);
            decimal BalanceActuales = ingresosActuales - egresosActuales;
            decimal ingresosPasados = MovRepository.SumaFecha(userId, 1, inicioMesPasado, finMesPasado);
            decimal egresosPasados = MovRepository.SumaFecha(userId, 2, inicioMesPasado, finMesPasado);
            decimal BalancePasados = ingresosPasados - egresosPasados;
            data.TotalIngresos = ingresosActuales;
            data.TotalEgresos = egresosActuales;
            data.Balance = BalanceActuales;
            data.PorcentajeBalance = Calcular(BalanceActuales, BalancePasados);
            data.PorcentajeIngresos = Calcular(ingresosActuales, ingresosPasados);
            data.PorcentajeEgresos = Calcular(egresosActuales, egresosPasados);
            data.dIngresos = MovRepository.CPI(userId, 1);
            data.dEgresos = MovRepository.CPE(userId, 2);
            data.DetalleMov = MovRepository.MostrarMovimientos(userId);
            data.DetallePed = pedidos.MostrarPedidos(userId);
            return data;
        }
        private decimal Calcular(decimal actual, decimal pasado)
        {
            if (pasado == 0)
            {
                return actual != 0 ? 100m : 0m;
            }
            return ((actual - pasado) / Math.Abs(pasado)) * 100;
        }
    }
}
