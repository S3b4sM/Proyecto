﻿using ENTITY;
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
                    string query = "SELECT ID_TIPO, NOMBRE FROM TIPOS Order By NOMBRE";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        OracleDataAdapter adapter = new OracleDataAdapter(command);
                        adapter.Fill(dataTable);
                        DataRow placeholderRow = dataTable.NewRow();
                        placeholderRow["ID_TIPO"] = 0;
                        placeholderRow["NOMBRE"] = "TIPO";
                        dataTable.Rows.InsertAt(placeholderRow, 0);
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
    }
}
