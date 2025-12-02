using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class ClientesRepository
    {
        private readonly string _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xepdb1)));User Id=proyecto;Password=sebas123;";
        public bool AggClientes(Clientes cliente)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO CLIENTES 
                                     (DOCUMENTO, NOMBRE, TELEFONO, ID_USUARIO, DIRECCION)
                                     VALUES 
                                     (:p_doc, :p_nom, :p_tel, :p_id_user, :p_direccion)";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.BindByName = true;
                        command.Parameters.Add("p_doc", OracleDbType.Varchar2).Value = cliente.documento;
                        command.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = cliente.nombre;
                        command.Parameters.Add("p_tel", OracleDbType.Varchar2).Value = cliente.telefono;
                        command.Parameters.Add("p_id_user", OracleDbType.Int32).Value = cliente.id_user;
                        command.Parameters.Add("p_direccion", OracleDbType.Varchar2).Value = cliente.direccion;
                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                    {
                        throw new Exception("Ya existe un cliente registrado con este número de documento.");
                    }
                    throw;
                }
            }
        }
        public bool ActualizarCliente(Clientes cliente)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE CLIENTES SET DOCUMENTO = :p_doc_nuevo, NOMBRE = :p_nom, TELEFONO = :p_tel, DIRECCION = :p_direccion, 
                                    CONTORNO_BUSTO = :p_c_busto, CONTORNO_CINTURA = :p_c_cintura,
                                    CONTORNO_CADERA = :p_c_cadera, ANCHO_ESPALDA = :p_a_espalda,
                                    TALLE_DELANTERO = :p_t_delantero, TALLE_ESPALDA = :p_t_espalda,
                                    LARGO_BRAZO = :p_l_brazo, CONTORNO_CUELLO = :p_c_cuello,
                                    CONTORNO_MUNECA = :p_c_muneca, CONTORNO_BRAZO_BICEPS = :p_c_biceps,
                                    FECHA_ULTIMA_MEDIDA = SYSDATE
                                    WHERE DOCUMENTO = :p_doc";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("p_doc_nuevo", OracleDbType.Varchar2).Value = cliente.documento;
                        command.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = cliente.nombre;
                        command.Parameters.Add("p_tel", OracleDbType.Varchar2).Value = cliente.telefono;
                        command.Parameters.Add("p_direccion", OracleDbType.Varchar2).Value = cliente.direccion;
                        command.Parameters.Add("p_c_busto", OracleDbType.Decimal).Value = GetDbValue(cliente.contorno_busto);
                        command.Parameters.Add("p_c_cintura", OracleDbType.Decimal).Value = GetDbValue(cliente.contorno_cintura);
                        command.Parameters.Add("p_c_cadera", OracleDbType.Decimal).Value = GetDbValue(cliente.contorno_cadera);
                        command.Parameters.Add("p_a_espalda", OracleDbType.Decimal).Value = GetDbValue(cliente.ancho_espalda);
                        command.Parameters.Add("p_t_delantero", OracleDbType.Decimal).Value = GetDbValue(cliente.talle_delantero);
                        command.Parameters.Add("p_t_espalda", OracleDbType.Decimal).Value = GetDbValue(cliente.talle_espalda);
                        command.Parameters.Add("p_l_brazo", OracleDbType.Decimal).Value = GetDbValue(cliente.largo_brazo);
                        command.Parameters.Add("p_c_cuello", OracleDbType.Decimal).Value = GetDbValue(cliente.contorno_cuello);
                        command.Parameters.Add("p_c_muneca", OracleDbType.Decimal).Value = GetDbValue(cliente.contorno_muneca);
                        command.Parameters.Add("p_c_biceps", OracleDbType.Decimal).Value = GetDbValue(cliente.contorno_brazo_biceps);
                        command.Parameters.Add("p_doc", OracleDbType.Varchar2).Value = cliente.documento;
                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool EliminarCliente(int documento)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM CLIENTES WHERE DOCUMENTO = :p_doc";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("p_doc", OracleDbType.Varchar2).Value = documento;
                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 2292)
                    {
                        throw new Exception("No se puede eliminar el cliente porque tiene pedidos asociados.");
                    }
                    throw;
                }
            }
        }
        public DataTable MostrarClientes(int id_user)
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT DOCUMENTO, NOMBRE, TELEFONO, DIRECCION, FECHA_ULTIMA_MEDIDA AS ""Última Medida"",
                                    CASE 
                                    WHEN FECHA_ULTIMA_MEDIDA IS NULL THEN 'Pendiente Inicial'
                                    WHEN MONTHS_BETWEEN(SYSDATE, FECHA_ULTIMA_MEDIDA) >= 3 THEN 'Requiere Actualización'
                                    ELSE 'Al día'
                                    END AS ""Estado Medidas""
                                    FROM CLIENTES
                                    WHERE ID_USUARIO = :p_id_user
                                    ORDER BY NOMBRE ASC";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener clientes: " + ex.Message);
                    return null;
                }
            }
            return dataTable;
        }
        private object GetDbValue(decimal? value)
        {
            if (value.HasValue) return value.Value;
            return DBNull.Value;
        }
        public int ContarClientes(int id_user)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM CLIENTES WHERE ID_USUARIO = :p_id_user";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al contar clientes: " + ex.Message);
                    return 0;
                }
            }
        }
        public int ClientesMensuales(int id_user)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT COUNT(*) FROM CLIENTES 
                                     WHERE ID_USUARIO = :p_id_user 
                                     AND TRUNC(FECHA_ULTIMA_MEDIDA, 'MM') = TRUNC(SYSDATE, 'MM')";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al contar clientes mensuales: " + ex.Message);
                    return 0;
                }
            }
        }
        public DataTable ObtenerClientes(int id_user)
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DOCUMENTO, NOMBRE FROM CLIENTES WHERE ID_USUARIO = :p_id_user ORDER BY NOMBRE ASC";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_id_user", id_user));
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener clientes para combo: " + ex.Message);
                    return null;
                }
            }
            return dataTable;
        }
        public bool ActualizarMedidas(Clientes cliente)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE CLIENTES SET 
                                CONTORNO_BUSTO = :p_busto,
                                CONTORNO_CINTURA = :p_cintura,
                                CONTORNO_CADERA = :p_cadera,
                                ANCHO_ESPALDA = :p_ancho_esp,
                                TALLE_DELANTERO = :p_talle_del,
                                TALLE_ESPALDA = :p_talle_esp,
                                LARGO_BRAZO = :p_largo_brazo,
                                CONTORNO_CUELLO = :p_cuello,
                                CONTORNO_MUNECA = :p_muneca,
                                CONTORNO_BRAZO_BICEPS = :p_biceps,
                                FECHA_ULTIMA_MEDIDA = SYSDATE
                             WHERE DOCUMENTO = :p_documento";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        object Val(decimal? v) => v.HasValue ? (object)v.Value : DBNull.Value;

                        command.Parameters.Add("p_busto", OracleDbType.Decimal).Value = Val(cliente.contorno_busto);
                        command.Parameters.Add("p_cintura", OracleDbType.Decimal).Value = Val(cliente.contorno_cintura);
                        command.Parameters.Add("p_cadera", OracleDbType.Decimal).Value = Val(cliente.contorno_cadera);
                        command.Parameters.Add("p_ancho_esp", OracleDbType.Decimal).Value = Val(cliente.ancho_espalda);
                        command.Parameters.Add("p_talle_del", OracleDbType.Decimal).Value = Val(cliente.talle_delantero);
                        command.Parameters.Add("p_talle_esp", OracleDbType.Decimal).Value = Val(cliente.talle_espalda);
                        command.Parameters.Add("p_largo_brazo", OracleDbType.Decimal).Value = Val(cliente.largo_brazo);
                        command.Parameters.Add("p_cuello", OracleDbType.Decimal).Value = Val(cliente.contorno_cuello);
                        command.Parameters.Add("p_muneca", OracleDbType.Decimal).Value = Val(cliente.contorno_muneca);
                        command.Parameters.Add("p_biceps", OracleDbType.Decimal).Value = Val(cliente.contorno_brazo_biceps);

                        command.Parameters.Add("p_documento", OracleDbType.Varchar2).Value = cliente.documento;

                        int filas = command.ExecuteNonQuery();
                        return filas > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar medidas: " + ex.Message);
                    return false;
                }
            }
        }
        public Clientes ObtenerClientePorDocumento(int documento)
        {
            Clientes cliente = null;
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM CLIENTES WHERE DOCUMENTO = :p_doc --AND ID_USUARIO = :p_id_user";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("p_doc", OracleDbType.Varchar2).Value = documento.ToString(); 
                        //command.Parameters.Add("p_id_user", OracleDbType.Int32).Value = idUsuario;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cliente = new Clientes();
                                cliente.documento = reader["DOCUMENTO"].ToString();
                                cliente.nombre = reader["NOMBRE"].ToString();
                                cliente.telefono = reader["TELEFONO"] != DBNull.Value ? reader["TELEFONO"].ToString() : "";
                                cliente.direccion = reader["DIRECCION"] != DBNull.Value ? reader["DIRECCION"].ToString() : "";
                                cliente.contorno_busto = reader["CONTORNO_BUSTO"] != DBNull.Value ? Convert.ToDecimal(reader["CONTORNO_BUSTO"]) : (decimal?)null;
                                cliente.contorno_cintura = reader["CONTORNO_CINTURA"] != DBNull.Value ? Convert.ToDecimal(reader["CONTORNO_CINTURA"]) : (decimal?)null;
                                cliente.contorno_cadera = reader["CONTORNO_CADERA"] != DBNull.Value ? Convert.ToDecimal(reader["CONTORNO_CADERA"]) : (decimal?)null;
                                cliente.ancho_espalda = reader["ANCHO_ESPALDA"] != DBNull.Value ? Convert.ToDecimal(reader["ANCHO_ESPALDA"]) : (decimal?)null;
                                cliente.talle_delantero = reader["TALLE_DELANTERO"] != DBNull.Value ? Convert.ToDecimal(reader["TALLE_DELANTERO"]) : (decimal?)null;
                                cliente.talle_espalda = reader["TALLE_ESPALDA"] != DBNull.Value ? Convert.ToDecimal(reader["TALLE_ESPALDA"]) : (decimal?)null;
                                cliente.largo_brazo = reader["LARGO_BRAZO"] != DBNull.Value ? Convert.ToDecimal(reader["LARGO_BRAZO"]) : (decimal?)null;
                                cliente.contorno_cuello = reader["CONTORNO_CUELLO"] != DBNull.Value ? Convert.ToDecimal(reader["CONTORNO_CUELLO"]) : (decimal?)null;
                                cliente.contorno_muneca = reader["CONTORNO_MUNECA"] != DBNull.Value ? Convert.ToDecimal(reader["CONTORNO_MUNECA"]) : (decimal?)null;
                                cliente.contorno_brazo_biceps = reader["CONTORNO_BRAZO_BICEPS"] != DBNull.Value ? Convert.ToDecimal(reader["CONTORNO_BRAZO_BICEPS"]) : (decimal?)null;
                                if (reader["FECHA_ULTIMA_MEDIDA"] != DBNull.Value)
                                {
                                    cliente.fecha_ultima_medida = Convert.ToDateTime(reader["FECHA_ULTIMA_MEDIDA"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener cliente: " + ex.Message);
                    return null;
                }
            }
            return cliente;
        }
    }
}
