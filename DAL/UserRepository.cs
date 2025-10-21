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
                    string query = "SELECT USERID, USERNAME, FIRSTNAME, LASTNAME FROM Users WHERE USERNAME = :p_user AND PASSWORD = :p_pass";
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
                                    LastName = rd["LASTNAME"].ToString()
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
        public Usuario Register(string user, string pass, string firstName, string lastName)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Users (USERNAME, PASSWORD, FIRSTNAME, LASTNAME) VALUES (:p_user, :p_pass, :p_firstName, :p_lastName) RETURNING USERID INTO :p_userId";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_user", user.Trim().ToLower()));
                        command.Parameters.Add(new OracleParameter("p_pass", pass.Trim().ToLower()));
                        command.Parameters.Add(new OracleParameter("p_firstName", firstName.Trim()));
                        command.Parameters.Add(new OracleParameter("p_lastName", lastName.Trim()));
                        Oracle.ManagedDataAccess.Client.OracleParameter userIdParam = new Oracle.ManagedDataAccess.Client.OracleParameter("p_userId", Oracle.ManagedDataAccess.Client.OracleDbType.Int32);
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
                                LastName = lastName
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
        public bool UserExists(string username)
        {
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE USERNAME = :p_user";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter("p_user", username));
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
