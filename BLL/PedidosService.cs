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
        public bool AggPedido(Pedidos pedidos)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    Pedidos nuevoPedido = PedidosRepository.AggPedido(
                        pedidos
                    );
                    if (nuevoPedido == null)
                    {
                        return false;
                    }
                    if (pedidos.abono > 0)
                    {
                        int idTipoIngreso = 1;
                        int idCatAbonoPedido = 17;
                        String descripcion = $"Abono inicial para pedido. Desc: {pedidos.descripcion.Substring(0, Math.Min(pedidos.descripcion.Length, 20))}...";
                        Movimiento movimientGuardado = movRepo.Agg(DateTime.Now, pedidos.abono, idTipoIngreso, pedidos.id_usuario, idCatAbonoPedido, descripcion);

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
        public int PedidosSemanal(int id_user)
        {
            return PedidosRepository.PedidosSemanal(id_user);
        }
        public DataTable PedidoPorId(int id_pedido)
        {
            return PedidosRepository.PedidoPorId(id_pedido);
        }
    }
}
