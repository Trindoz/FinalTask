using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.DAL.Interfaces;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace FinalTask.DAL
{

    public class UserDao : IUserDao
    {
        private string _connection = "Data Source=.;Initial Catalog=FinalTask;Integrated Security=True";
       
        public User Add(User user)
        {
            string commandText = "dbo.AddUser";
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters["@Name"].Value = user.Name;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar);
                command.Parameters["@LastName"].Value = user.LastName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar);
                command.Parameters["@Email"].Value = user.EMail;
                command.Parameters.Add("@Login", SqlDbType.NVarChar);
                command.Parameters["@Login"].Value = user.Login;
                command.Parameters.Add("@Password", SqlDbType.NVarChar);
                command.Parameters["@Password"].Value = user.Password;
                command.Parameters.Add("@Photo", SqlDbType.NVarChar);
                command.Parameters["@Photo"].Value = user.Photo;
                command.Parameters.Add("@Birthday", SqlDbType.Date);
                command.Parameters["@Birthday"].Value = user.Birthday;
                command.Parameters.Add("@Age", SqlDbType.Int);
                command.Parameters["@Age"].Value = user.Age;
                command.Parameters.Add("@Role", SqlDbType.NVarChar);
                command.Parameters["@Role"].Value = user.Role;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool Delete(int id)
        {
            var user = new User();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("DELETE FROM[User] WHERE Id = '{0}'", id);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        user.Id = (int)reader["id"];
                        user.Name = reader["name"] as string;
                        user.LastName = reader["lastname"] as string;
                        user.EMail = reader["email"] as string;
                        user.Login = reader["login"] as string;
                        user.Password = reader["password"] as string;
                        user.Photo = reader["photo"] as string;
                        user.Birthday = (DateTime)reader["birthday"];
                        user.Role = reader["roleid"] as string;
                    };
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Id,Name,LastName,Email,(SELECT Login FROM [Logins] WHERE Id=LoginId) AS Login,(SELECT Password FROM [Passwords] WHERE Id=PasswordId) as Password,Photo,Birthday,RoleId FROM[User] ";
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        users.Add(new User
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
                        }) ;
                    }

                    return users;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public User GetById(int id)
        {
            var user = new User();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("SELECT [ID],[NAME],[LASTNAME],[EMAIL],[Login],[PASSWORD],[PHOTO],[BIRTHDAY],[AGE],[ROLEID]FROM[dbo].[User]WHERE Id ='{0}'",id);
                connection.Open();
                var reader = command.ExecuteReader();
                try 
                {
                    while (reader.Read())
                    {
                        user.Id = (int)reader["id"];
                        user.Name = reader["name"] as string;
                        user.LastName = reader["lastname"] as string;
                        user.EMail = reader["email"] as string;
                        user.Login = reader["login"] as string;
                        user.Password = reader["password"] as string;
                        user.Photo = reader["photo"] as string;
                        user.Birthday = (DateTime)reader["birthday"];
                        user.Role = reader["roleid"] as string;
                    };
                    return user; 
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public User Update(User user)
        {

            string commandText = "dbo.UpdateUser";
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Email", user.EMail);              
                command.Parameters.AddWithValue("@Login", user.Login);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Photo", user.Photo);
                command.Parameters.AddWithValue("@Birthday",user.Birthday);
                command.Parameters.AddWithValue("@Age", user.Age);
                command.Parameters.AddWithValue("@Role", user.Role);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public User GetUserByLogin(string login)
        {
            var user = new User();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("SELECT Id,Name,LastName,Email,(SELECT Login FROM [Logins] WHERE Id=LoginId) AS Login,(SELECT Password FROM [Passwords] WHERE Id=PasswordId) AS Password,Photo,Birthday,RoleId FROM[User] WHERE LoginId=(SELECT Id FROM[Logins] WHERE Login='{0}')",login);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        user.Id = (int)reader["id"];
                        user.Name = reader["name"] as string;
                        user.LastName = reader["lastname"] as string;
                        user.EMail = reader["email"] as string;
                        user.Login = reader["login"] as string;
                        user.Password = reader["password"] as string;
                        user.Photo = reader["photo"] as string;
                        user.Birthday = (DateTime)reader["birthday"];
                        user.Role = reader["roleid"] as string;
                    }
                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
