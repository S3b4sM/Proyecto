using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository
    {
        private readonly string _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xepdb1)));User Id=proyecto;Password=sebas123;";
        public Usuario Validate(string user, string pass)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT USERID, USERNAME, FIRSTNAME, LASTNAME, DOCUMENTO FROM Users WHERE USERNAME = :p_user AND PASSWORD = :p_pass";
                    using (OracleCommand reader = new OracleCommand(query, connection))
                    {
                        reader.Parameters.Add(new OracleParameter("p_user", user.Trim().ToLower()));
                        reader.Parameters.Add(new OracleParameter("p_pass", pass));
                        using (OracleDataReader rd = reader.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                Usuario usuario = new Usuario
                                {
                                    Id = Convert.ToInt32(rd["USERID"]),
                                    Username = rd["USERNAME"].ToString(),
                                    FirstName = rd["FIRSTNAME"].ToString(),
                                    LastName = rd["LASTNAME"].ToString(),
                                    Document = Convert.ToInt32(rd["DOCUMENTO"])
                                };
                            return usuario;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/validar el usuario: " + ex.Message);
                    return null;
                }
            }
        }  
        public Usuario Register(string user, string pass, string firstName, string lastName, int document)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Users (USERNAME, PASSWORD, FIRSTNAME, LASTNAME, DOCUMENTO) VALUES (:p_user, :p_pass, :p_firstName, :p_lastName, :p_doc) RETURNING USERID INTO :p_userId";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_user", user.Trim().ToLower()));
                        command.Parameters.Add(new OracleParameter("p_pass", pass.Trim().ToLower()));
                        command.Parameters.Add(new OracleParameter("p_firstName", firstName.Trim()));
                        command.Parameters.Add(new OracleParameter("p_lastName", lastName.Trim()));
                        command.Parameters.Add(new OracleParameter("p_doc", document));
                        OracleParameter userIdParam = new OracleParameter("p_userId", OracleDbType.Int32);
                        userIdParam.Direction = System.Data.ParameterDirection.Output;
                        command.Parameters.Add(userIdParam);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            int userId = Convert.ToInt32(userIdParam.Value.ToString());
                            Usuario usuario = new Usuario
                            {
                                Id = userId,
                                Username = user,
                                Password = pass,
                                FirstName = firstName,
                                LastName = lastName,
                                Document = document
                            };
                            return usuario;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/registrar el usuario: " + ex.Message);
                    return null;
                }
            }
        }
        public bool UserExists(string username, int doc)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE USERNAME = :p_user AND DOCUMENTO = :p_doc";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_user", username));
                        command.Parameters.Add(new OracleParameter("p_doc", username));
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos/verificar el usuario: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
