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

        public bool AddArticle(Article article)
        {
            string commandText = "dbo.AddArticle";
            using (SqlConnection connection= new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", article.Name);
                command.Parameters.AddWithValue("@image", article.Image);
                command.Parameters.AddWithValue("@content", article.Content);
                command.Parameters.AddWithValue("@analystId", article.Autor.Id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool Delete(int id)
        {
            var analyst = new Analyst();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("DELETE FROM FinalTask.[dbo].[Analysts] WHERE Id='{0}'", id);
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

        public bool DeleteArticle(Article article)
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
                command.CommandText = "SELECT * FROM Analysts";
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {          
                        analysts.Add(new Analyst
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"] as string,
                            LastName = reader["lastname"] as string,
                            EMail = reader["email"] as string,
                            Login = reader["login"] as string,
                            Password = reader["password"] as string,
                            Photo = reader["photo"] as string,
                            Article = GetArticlesByAnalystId((int)reader["Id"]).ToList(),
                            Birthday = (DateTime)reader["birthday"],
                            Role = reader["roleid"] as string
                        }) ;
                        
                    }
                    return analysts.Distinct();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public IEnumerable<Article> GetArticles()
        {
            var articles = new List<Article>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Articles";
                connection.Open();
                var reader = command.ExecuteReader();
                try {
                    while (reader.Read())
                    {
                        articles.Add(
                                       new Article
                                       {
                                           Id = (int)reader["Id"],
                                           Name = reader["Name"] as string,
                                           Image = reader["Image"] as string,
                                           Autor = GetById((int)reader["AnalystId"]),
                                           Content = reader["Content"] as string,
                                           Likes = (int)reader["Likes"],
                                           DisLikes = (int)reader["Dislikes"]
                                       });
                    }
                    return articles;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public IEnumerable<Article> GetArticlesByAnalystId(int id)
        {
            var articles = new List<Article>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("SELECT * FROM Articles Where AnalystId='{0}'", id);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        articles.Add(
                                       new Article
                                       {
                                           Id = (int)reader["Id"],
                                           Name = reader["Name"] as string,
                                           Image = reader["Image"] as string,
                                           Autor = GetById((int)reader["AnalystId"]),
                                           Content = reader["Content"] as string,
                                           Likes = (int)reader["Likes"],
                                           DisLikes = (int)reader["Dislikes"]
                                       });
                    }
                    return articles;
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
                command.CommandText = string.Format("SELECT * FROM[dbo].[Analysts]WHERE Id ='{0}'", id);
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
                        analyst.Article = GetArticlesByAnalystId((int)reader["id"]).ToList();
                        analyst.Rating = (int)reader["rating"]; 
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

        public Analyst GetByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public List<string> GetEmails()
        {
            throw new NotImplementedException();
        }

        public List<string> GetLogins()
        {
            throw new NotImplementedException();
        }

        public List<string> GetPasswords()
        {
            throw new NotImplementedException();
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

