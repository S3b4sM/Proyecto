using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PedidosRepository
    {
        private readonly string _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xepdb1)));User Id=proyecto;Password=sebas123;";
        public Pedidos AggPedido(int id_user, string desc, decimal precioT, decimal abono, string estado, DateTime fecha_pedido, DateTime fecha_entrega)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO PEDIDOS (ID_USER, DESCRIPCION, PRECIO_TOTAL, ABONO, ESTADO, FECHA_INICIO, FECHA_ENTREGA) VALUES (:p_id_user, :p_desc, :p_precioT, :p_abono, :p_estado, :p_fecha_p, :p_fecha_e ) RETURNING ID_PEDIDO INTO :p_id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        command.Parameters.Add(new OracleParameter("p_desc", desc));
                        command.Parameters.Add(new OracleParameter("p_precioT", precioT));
                        command.Parameters.Add(new OracleParameter("p_abono", abono));
                        command.Parameters.Add(new OracleParameter("p_estado", estado));
                        command.Parameters.Add(new OracleParameter("p_fecha_p", fecha_pedido));
                        command.Parameters.Add(new OracleParameter("p_fecha_e", fecha_entrega));
                        OracleParameter idParam = new OracleParameter("p_id", OracleDbType.Int32);
                        idParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(idParam);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            int pedidoId = Convert.ToInt32(idParam.Value.ToString());
                            Pedidos pedidos = new Pedidos
                            {
                                id_pedido = pedidoId,
                                id_usuario = id_user,
                                descripcion = desc,
                                precio_total = precioT,
                                abono = abono,
                                estado = estado,
                                fecha_pedido = fecha_pedido,
                                fecha_entrega = fecha_entrega
                            };
                            return pedidos;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/agregar el pedido: " + ex.Message);
                    return null;
                }
            }
        }
        public DataTable MostrarPedidos(int id_user)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    string query = @"SELECT p.ID_PEDIDO, p.precio_total, p.abono, p.estado,
                                    p.fecha_inicio as INICIO, p.fecha_entrega AS ENTREGA, p.id_user, p.descripcion
                                    FROM PEDIDOS p
                                    JOIN users u ON p.id_user = u.userid
                                    WHERE p.id_user = :p_id_user 
                                    ORDER BY FECHA_INICIO DESC";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/mostrar pedidos: " + ex.Message);
                    return null;
                }
                return dataTable;
            }
        }
        public bool ActualizarPedido(Pedidos pedidos)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE PEDIDOS SET DESCRIPCION = :p_desc, PRECIO_TOTAL = :p_precioT, ABONO = :p_abono, ESTADO = :p_estado, FECHA_INICIO = :p_fecha_p, FECHA_ENTREGA = :p_fecha_e WHERE ID_PEDIDO = :p_id_pedido";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_desc", pedidos.descripcion));
                        command.Parameters.Add(new OracleParameter("p_precioT", pedidos.precio_total));
                        command.Parameters.Add(new OracleParameter("p_abono", pedidos.abono));
                        command.Parameters.Add(new OracleParameter("p_estado", pedidos.estado));
                        command.Parameters.Add(new OracleParameter("p_fecha_p", pedidos.fecha_pedido));
                        command.Parameters.Add(new OracleParameter("p_fecha_e", pedidos.fecha_entrega));
                        command.Parameters.Add(new OracleParameter("p_id_pedido", pedidos.id_pedido));
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/actualizar el pedido: " + ex.Message);
                    return false;
                }
            }
        }
        public bool EliminarPedido(int id_pedido)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM PEDIDOS WHERE ID_PEDIDO = :p_id_pedido";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_pedido", id_pedido));
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/eliminar el pedido: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
