using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public  class PedidosService
    {
        PedidosRepository PedidosRepository = new PedidosRepository();
        private MovRepository movRepo = new MovRepository();
        public bool AggPedido(int id_user, string desc, decimal precioT, decimal abono, string estado, DateTime fecha_inicio, DateTime fecha_entrega)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    Pedidos nuevoPedido = PedidosRepository.AggPedido(
                        id_user, desc, precioT, abono, estado, fecha_inicio, fecha_entrega
                    );
                    if (nuevoPedido == null)
                    {
                        return false;
                    }
                    if (abono > 0)
                    {
                        int idTipoIngreso = 1;
                        int idCatAbonoPedido = 18;
                        String descripcion = $"Abono inicial para pedido. Desc: {desc.Substring(0, Math.Min(desc.Length, 20))}...";
                        Movimiento movimientGuardado = movRepo.Agg(DateTime.Now, abono, idTipoIngreso, id_user, idCatAbonoPedido, descripcion);

                        if (movimientGuardado == null)
                        {
                            throw new Exception("Error al guardar el movimiento de abono asociado al pedido.");
                        }
                    }
                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en Crear Nuevo Pedido: " + ex.Message);
                    throw;
                }
            }
        }
        public DataTable MostrarPedidos (int id)
        {
            return PedidosRepository.MostrarPedidos(id);
        }
        public bool ActualizarPedido(Pedidos pedidos)
        {
            return PedidosRepository.ActualizarPedido(pedidos);
        }
        public bool EliminarPedido(int id_pedido)
        {
            return PedidosRepository.EliminarPedido(id_pedido);
        }

        public int PedPendientes(int id)
        {
            return PedidosRepository.PedPendientes(id);
        }
    }
}
