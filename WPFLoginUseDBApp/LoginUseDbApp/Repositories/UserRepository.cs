using LoginUseDbApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.ObjectModel;

namespace LoginUseDbApp.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
     
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username and [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
                connection.Close();
            }
            return validUser;
        }

        public void Edit(string id, string userName, string password, string name, string lastName, string email)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Update [User]  SET Username=@Username,Password=@Password,Name=@Name,LastName=@LastName,Email=@Email where Id=@Id";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Username", userName);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteReader();
            }
        }
        public ObservableCollection<UserModel> GetByAll()
        {
            ObservableCollection<UserModel> listUser = new ObservableCollection<UserModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User]";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserModel()
                        {
                            Id = reader["Id"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                        };
                        listUser.Add(user);
                    }
                }
                connection.Close();
            }
            return listUser;
        }




        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }
        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString(),
                        };
                    }
                }
                connection.Close();
            }
            return user;
        }
        public void Remove(String id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Delete from [User] where Id ="+ id + "";
                command.ExecuteReader();
                connection.Close();

            }
        }
        public void Insert(string userName, string password, string name, string lastName, string email)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert into [User] Values (@Username,@Password,@Name,@LastName,@Email)";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Username", userName);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteReader();
            }
        }
    }
}
