using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommonDao:ICommonDao
    {
        private string _connection = "Data Source=.;Initial Catalog=FinalTask;Integrated Security=True";

        public List<string> GetUserLogins()
        {
            var logins = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Login FROM[Logins]";
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        string login = reader["Login"] as string;
                        logins.Add(login);
                    }
                    return logins;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<string> GetUserPasswords()
        {
            var passwords = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Password FROM[Passwords]";
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        string password = reader["Password"] as string;
                        passwords.Add(password);
                    }
                    return passwords;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
