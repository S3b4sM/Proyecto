using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;
using System.Threading;

namespace DAL
{
    public class MovRepository
    {
        private readonly string _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xepdb1)));User Id=proyecto;Password=sebas123;";
        public Movimiento Agg(DateTime fecha, decimal monto, int tipo, int id_user, int id_cat)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Movimientos (FECHA, MONTO, ID_USER, ID_CATEGORIA, ID_TIPO) VALUES (:p_fecha, :p_monto, :p_id_user, :p_id_cat, :p_tipo) RETURNING ID_MOVIMIENTO INTO :p_id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_fecha", fecha));
                        command.Parameters.Add(new OracleParameter("p_monto", monto));
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        command.Parameters.Add(new OracleParameter("p_id_cat", id_cat));
                        command.Parameters.Add(new OracleParameter("p_tipo", tipo));
                        OracleParameter idParam = new OracleParameter("p_id", OracleDbType.Int32);
                        idParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(idParam);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            int movimientoId = Convert.ToInt32(idParam.Value.ToString());
                            Movimiento movimiento = new Movimiento
                            {
                                id = movimientoId,
                                fecha = fecha,
                                monto = monto,
                                tipo = tipo,
                                id_user = id_user,
                                id_categoria = id_cat
                            };
                            return movimiento;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/agregar el movimiento: " + ex.Message);
                    return null;
                }
            }
        }
        public DataTable CPI(int id_user, int tipo) 
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT c.NOMBRE, SUM(m.MONTO) as TOTAL
                                    FROM Movimientos m
                                    JOIN CATEGORIAS c ON m.ID_CATEGORIA = c.ID_CATEGORIA
                                    JOIN TIPOS t ON m.ID_TIPO = t.ID_TIPO
                                    WHERE m.ID_USER = :p_id_user AND t.ID_TIPO = :p_tipo
                                    GROUP BY c.NOMBRE";
                    using (OracleCommand reader = new OracleCommand(query, connection))
                    {
                        reader.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        reader.Parameters.Add(new OracleParameter("p_tipo", tipo));
                        OracleDataAdapter adapter = new OracleDataAdapter(reader);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/obtener ingresos: " + ex.Message);
                    return null;
                }
            }
            return dataTable;
        }
        public DataTable CPE (int id_user, int tipo)
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT c.NOMBRE, SUM(m.MONTO) as TOTAL
                                    FROM Movimientos m
                                    JOIN CATEGORIAS c ON m.ID_CATEGORIA = c.ID_CATEGORIA 
                                    JOIN TIPOS t ON m.ID_TIPO = t.ID_TIPO
                                    WHERE m.ID_USER = :p_id_user AND t.ID_TIPO = :p_tipo
                                    GROUP BY c.NOMBRE";
                    using (OracleCommand reader = new OracleCommand(query, connection))
                    {
                        reader.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        reader.Parameters.Add(new OracleParameter("p_tipo", tipo));
                        OracleDataAdapter adapter = new OracleDataAdapter(reader);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/obtener egresoss: " + ex.Message);
                    return null;
                }
            }
            return dataTable;
        }
        public decimal SumIngresos(int id_user, int tipo)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SUM(MONTO) FROM MOVIMIENTOS WHERE ID_USER = :p_id_user AND ID_TIPO = :p_id_tipo";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleCommand reader = new OracleCommand(query, connection))
                        {
                            command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                            command.Parameters.Add(new OracleParameter("p_id_tipo", tipo));
                            object result = command.ExecuteScalar(); 
                            if (result != null && result != DBNull.Value)
                            {
                                return Convert.ToDecimal(result); 
                            }
                            else
                            {
                                return 0m;
                            }
                        }
                    }   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/obtener suma: " + ex.Message);
                    return 0m;
                }
            }
        }
        public decimal SumEgresos(int id_user, int tipo)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SUM(MONTO) FROM MOVIMIENTOS WHERE ID_USER = :p_id_user AND ID_TIPO = :p_id_tipo";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleCommand reader = new OracleCommand(query, connection))
                        {
                            command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                            command.Parameters.Add(new OracleParameter("p_id_tipo", tipo));
                            object result = command.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                return Convert.ToDecimal(result);
                            }
                            else
                            {
                                return 0m;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/obtener egreso: " + ex.Message);
                    return 0m;
                }
            }
        }
        public bool Actualizar(Movimiento movimiento)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE MOVIMIENTOS SET FECHA = :p_fecha, MONTO = :p_monto, ID_TIPO = :p_tipo, ID_USER = :p_id_user, ID_CATEGORIA = :p_id_cat WHERE ID_MOVIMIENTO = :p_id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_fecha", movimiento.fecha));
                        command.Parameters.Add(new OracleParameter("p_monto", movimiento.monto));
                        command.Parameters.Add(new OracleParameter("p_tipo", movimiento.tipo));
                        command.Parameters.Add(new OracleParameter("p_id_user", movimiento.id_user));
                        command.Parameters.Add(new OracleParameter("p_id_cat", movimiento.id_categoria));
                        command.Parameters.Add(new OracleParameter("p_id", movimiento.id));
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/actualizar el movimiento: " + ex.Message);
                    return false;
                }
            }
        }
        public bool Eliminar(int id)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM MOVIMIENTOS WHERE ID_MOVIMIENTO = :p_id";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id", id));
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/eliminar el movimiento: " + ex.Message);
                    return false;
                }
            }
        }
        public DataTable MostrarMovimientos(int id_user)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    string query = @"SELECT m.ID_MOVIMIENTO, m.FECHA, m.MONTO, t.NOMBRE as TIPO, c.NOMBRE as CATEGORIA
                                    FROM MOVIMIENTOS m
                                    JOIN CATEGORIAS c ON m.ID_CATEGORIA = c.ID_CATEGORIA
                                    JOIN TIPOS t ON m.ID_TIPO = t.ID_TIPO
                                    WHERE ID_USER = :p_id_user 
                                    ORDER BY FECHA DESC";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/mostrar movimientos: " + ex.Message);
                    return null;
                }
                return dataTable;
            }
        }
        public DataTable DetalleMov(int id_user)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                DataTable dataTable = new DataTable();
                try
                {
                    connection.Open();
                    string query = @"SELECT m.ID_MOVIMIENTO, m.FECHA, m.MONTO, t.NOMBRE as TIPO, c.NOMBRE as CATEGORIA
                                    FROM MOVIMIENTOS m
                                    JOIN CATEGORIAS c ON m.ID_CATEGORIA = c.ID_CATEGORIA
                                    JOIN TIPOS t ON m.ID_TIPO = t.ID_TIPO
                                    WHERE m.ID_USER = :p_id_user
                                    ORDER BY m.FECHA DESC";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/mostrar detalle del movimiento: " + ex.Message);
                    return null;
                }
                return dataTable;
            }
        }
    }
}
