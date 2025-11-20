using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriaRepository
    {
        private readonly string _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xepdb1)));User Id=proyecto;Password=sebas123;";
        public DataTable cbxRazon()
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID_CATEGORIA, NOMBRE FROM Categorias Order By NOMBRE";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                        DataRow placeholderRow = dataTable.NewRow();
                        placeholderRow["ID_CATEGORIA"] = 0;
                        placeholderRow["NOMBRE"] = "RAZON";
                        dataTable.Rows.InsertAt(placeholderRow, 0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/obtener razon " + ex.Message);
                    return null;

                }
            }
            return dataTable;
        }
        public DataTable cbxTipo()
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID_TIPO, NOMBRE FROM TIPOS Order By ID_TIPO";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/obtener tipo " + ex.Message);
                    return null;

                }
            }
            return dataTable;
        }
        public DataTable CatPorTipo(bool esIngreso)
        {
            DataTable dt = new DataTable();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT ID_CATEGORIA, NOMBRE FROM CATEGORIAS WHERE ES_INGRESO = :EsIngreso ORDER BY NOMBRE";
                    using (OracleCommand cmd = new OracleCommand(sql, con))
                    {
                        cmd.Parameters.Add("EsIngreso", OracleDbType.Decimal).Value = esIngreso ? 1 : 0;
                        using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener categorías por tipo: " + ex.Message);
                }
            }
            return dt;
        }
    }
}
