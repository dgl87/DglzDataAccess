using BlogApp.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace BlogApp
{
    internal class Program
    {
        private const string STRING_CONNECTION = "Server=localhost,1433;Database=Blog;User ID=sa;Password=2w3e4r5t!@#;TrustServerCertificate=true";
        static void Main(string[] args)
        {
            //DeleteUser();
            //UpdateUser();
            //CreateUser();
            ReadUsers();
            //ReadUser();
        }
        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(STRING_CONNECTION))
            {
                var users = connection.GetAll<User>();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id} - {user.Name}");
                }
            }
        }
        public static void ReadUser()
        {
            using (var connection = new SqlConnection(STRING_CONNECTION))
            {
                var user = connection.Get<User>(1);
                Console.WriteLine(user.Name);
            }
        }
        public static void CreateUser()
        {
            var user = new User()
            {
                Name = "Cristina Soto",
                Email = "cristina@gmail.com",
                PasswordHash = "Hash",
                Bio = "Vendedora",
                Image = "https://",
                Slug = "cristina"
            };
            using (var connection = new SqlConnection(STRING_CONNECTION))
            {
                connection.Insert<User>(user);
                Console.WriteLine("Inserido com sucesso");
            }
        }
        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 12,
                Name = "Cristina Soto",
                Email = "cristina@gmail.com",
                PasswordHash = "Hash",
                Bio = "Vendedora",
                Image = "https://",
                Slug = "cristina"
            };
            using (var connection = new SqlConnection(STRING_CONNECTION))
            {
                connection.Update<User>(user);
                Console.WriteLine("Atualizado com sucesso");
            }
        }
        public static void DeleteUser()
        {
            using (var connection = new SqlConnection(STRING_CONNECTION))
            {
                var user = connection.Get<User>(5);
                connection.Delete<User>(user);
                Console.WriteLine("Exclusão realizada com sucesso");
            }
        }
    }
}
