using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class PedidosService
    {
        PedidosRepository PedidosRepository = new PedidosRepository();
        public Pedidos AggPedido(int id_user, string desc, decimal precioT, decimal abono, string estado, DateTime fecha_pedido, DateTime fecha_entrega)
        {
            return PedidosRepository.AggPedido(id_user, desc, precioT, abono, estado, fecha_pedido, fecha_entrega);
        }
    }
}
