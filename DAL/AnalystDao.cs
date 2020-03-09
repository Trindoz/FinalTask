using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class AnalystDao:IAnalystDao
    {
        private string _connection = "Data Source=.;Initial Catalog=FinalTask;Integrated Security=True";

        public Analyst Add(Analyst analyst)
        {
            string commandText = "dbo.AddAnalyst";
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = analyst.Name;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar);
                command.Parameters["@LastName"].Value = analyst.LastName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar);
                command.Parameters["@Email"].Value = analyst.EMail;
                command.Parameters.Add("@Login", SqlDbType.NVarChar);
                command.Parameters["@Login"].Value = analyst.Login;
                command.Parameters.Add("@Password", SqlDbType.NVarChar);
                command.Parameters["@Password"].Value = analyst.Password;
                command.Parameters.Add("@Photo", SqlDbType.NVarChar);
                command.Parameters["@Photo"].Value = analyst.Photo;
                command.Parameters.Add("@Birthday", SqlDbType.Date);
                command.Parameters["@Birthday"].Value = analyst.Birthday;
                command.Parameters.Add("@Age", SqlDbType.Int);
                command.Parameters["@Age"].Value = analyst.Age;
                command.Parameters.Add("@RoleId", SqlDbType.Int);
                command.Parameters["@RoleId"].Value = analyst.Role;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return analyst;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool AddArticle(int analystid, Article article)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var analyst = new Analyst();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("DELETE FROM FinalTask.[dbo].[Analyst] WHERE Id='{0}'", id);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        analyst.Id = (int)reader["id"];
                        analyst.Name = reader["name"] as string;
                        analyst.LastName = reader["lastname"] as string;
                        analyst.EMail = reader["email"] as string;
                        analyst.Login = reader["login"] as string;
                        analyst.Password = reader["password"] as string;
                        analyst.Photo = reader["photo"] as string;
                        analyst.Birthday = (DateTime)reader["birthday"];
                        analyst.Role = reader["roleid"] as string;
                    };
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool DeleteArticle(int analystid, Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Analyst> GetAll()
        {
            var analysts = new List<Analyst>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT [ID],[NAME],[LASTNAME],[EMAIL],[Login],[PASSWORD],[PHOTO],[BIRTHDAY],[AGE],[ROLEID]FROM[dbo].[Analyst]";
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        analysts.Add(new Analyst
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"] as string,
                            LastName = reader["lastname"] as string,
                            EMail = reader["email"] as string,
                            Login = reader["login"] as string,
                            Password = reader["password"] as string,
                            Photo = reader["photo"] as string,
                            Birthday = (DateTime)reader["birthday"],
                            Role = reader["roleid"] as string
                        });
                    }

                    return analysts;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public Analyst GetById(int id)
        {
            var analyst = new Analyst();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("SELECT [ID],[NAME],[LASTNAME],[EMAIL],[Login],[PASSWORD],[PHOTO],[BIRTHDAY],[AGE],[ROLEID]FROM[dbo].[Analyst]WHERE Id ='{0}'", id);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        analyst.Id = (int)reader["id"];
                        analyst.Name = reader["name"] as string;
                        analyst.LastName = reader["lastname"] as string;
                        analyst.EMail = reader["email"] as string;
                        analyst.Login = reader["login"] as string;
                        analyst.Password = reader["password"] as string;
                        analyst.Photo = reader["photo"] as string;
                        analyst.Birthday = (DateTime)reader["birthday"];
                        analyst.Role = reader["roleid"] as string;
                    };
                    return analyst;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public Analyst Update(Analyst analyst)
        {

            string commandText = "dbo.UpdateAnalyst";
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", analyst.Id);
                command.Parameters.AddWithValue("@Name", analyst.Name);
                command.Parameters.AddWithValue("@LastName", analyst.LastName);
                command.Parameters.AddWithValue("@Email", analyst.EMail);
                command.Parameters.AddWithValue("@Login", analyst.Login);
                command.Parameters.AddWithValue("@Password", analyst.Password);
                command.Parameters.AddWithValue("@Photo", analyst.Photo);
                command.Parameters.AddWithValue("@Birthday", analyst.Birthday);
                command.Parameters.AddWithValue("@Age", analyst.Age);
                command.Parameters.AddWithValue("@RoleId", analyst.Role);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return analyst;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}

