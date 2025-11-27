using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                     (DOCUMENTO, NOMBRE, APELLIDO, TELEFONO, ID_USUARIO)
                                     VALUES 
                                     (:p_doc, :p_nom, :p_ape, :p_tel, :p_ud_user)";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("p_doc", OracleDbType.Varchar2).Value = cliente.documento;
                        command.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = cliente.nombre;
                        command.Parameters.Add("p_ape", OracleDbType.Varchar2).Value = cliente.apellido;
                        command.Parameters.Add("p_tel", OracleDbType.Varchar2).Value = cliente.telefono;
                        command.Parameters.Add("p_id_user", OracleDbType.Int32).Value = cliente.id_user;
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
                    string query = @"UPDATE CLIENTES SET NOMBRE = :p_nom, APELLIDO = :p_ape, TELEFONO = :p_tel, 
                                    CONTORNO_BUSTO = :p_c_busto, CONTORNO_CINTURA = :p_c_cintura,
                                    CONTORNO_CADERA = :p_c_cadera, ANCHO_ESPALDA = :p_a_espalda,
                                    TALLE_DELANTERO = :p_t_delantero, TALLE_ESPALDA = :p_t_espalda,
                                    LARGO_BRAZO = :p_l_brazo, CONTORNO_CUELLO = :p_c_cuello,
                                    CONTORNO_MUNECA = :p_c_muneca, CONTORNO_BRAZO_BICEPS = :p_c_biceps,
                                    FECHA_ULTIMA_MEDIDA = SYSDATE
                                    WHERE DOCUMENTO = :p_doc";

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("p_nom", OracleDbType.Varchar2).Value = cliente.nombre;
                        command.Parameters.Add("p_ape", OracleDbType.Varchar2).Value = cliente.apellido;
                        command.Parameters.Add("p_tel", OracleDbType.Varchar2).Value = cliente.telefono;
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
        public bool EliminarCliente(string documento)
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
                    string query = @"SELECT DOCUMENTO, NOMBRE, APELLIDO, TELEFONO, FECHA_ULTIMA_MEDIDA AS ""Última Medida"",
                                    CASE 
                                    WHEN FECHA_ULTIMA_MEDIDA IS NULL THEN 'Pendiente Inicial'
                                    WHEN MONTHS_BETWEEN(SYSDATE, FECHA_ULTIMA_MEDIDA) >= 3 THEN 'Requiere Actualización'
                                    ELSE 'Al día'
                                    END AS ""Estado Medidas""
                                    FROM CLIENTES
                                    WHERE ID_USER = :p_id_user
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
    }
}
