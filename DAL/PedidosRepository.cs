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

                    using (OracleCommand command = new OracleCommand("PKG_MODISTAPP.SP_REGISTRAR_PEDIDO", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("p_id_user", OracleDbType.Int32).Value = id_user;
                        command.Parameters.Add("p_desc", OracleDbType.Varchar2).Value = desc;
                        command.Parameters.Add("p_precio", OracleDbType.Decimal).Value = precioT;
                        command.Parameters.Add("p_abono", OracleDbType.Decimal).Value = abono;
                        command.Parameters.Add("p_estado", OracleDbType.Varchar2).Value = estado;
                        command.Parameters.Add("p_fecha_inicio", OracleDbType.Date).Value = fecha_pedido;
                        command.Parameters.Add("p_fecha_entrega", OracleDbType.Date).Value = fecha_entrega;
                        OracleParameter idParam = new OracleParameter("p_id_nuevo_out", OracleDbType.Int32);
                        idParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(idParam);
                        command.ExecuteNonQuery();
                        int nuevoId = 0;
                        if (idParam.Value != null && idParam.Value != DBNull.Value)
                        {
                            if (int.TryParse(idParam.Value.ToString(), out int idConvertido))
                            {
                                nuevoId = idConvertido;
                            }
                        }
                        return new Pedidos
                        {
                            id_pedido = nuevoId,
                            id_usuario = id_user,
                            descripcion = desc,
                            precio_total = precioT,
                            abono = abono,
                            estado = estado,
                            fecha_pedido = fecha_pedido,
                            fecha_entrega = fecha_entrega
                        };
                    }
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 20002)
                    {
                        throw new InvalidOperationException(ex.Message);
                    }
                    Console.WriteLine("Error Oracle: " + ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error general: " + ex.Message);
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
                    string query = @"SELECT *
                                    FROM V_PEDIDOS_DETALLE
                                    WHERE ID_USER = :p_id_user 
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
                catch (OracleException ex)
                {
                    if (ex.Number == 20002)
                    {
                        throw new InvalidOperationException(ex.Message);
                    }
                    else
                    {
                        Console.WriteLine("Error de Oracle al actualizar pedido: " + ex.Message);
                        return false;
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
