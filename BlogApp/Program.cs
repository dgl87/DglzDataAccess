using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.Data.SqlClient;
using System;

namespace BlogApp
{
    internal class Program
    {
        private const string STRING_CONNECTION = "Server=localhost,1433;Database=Blog;User ID=sa;Password=2w3e4r5t!@#;TrustServerCertificate=true";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(STRING_CONNECTION);
            connection.Open();
            //DeleteUser(connection);
            //UpdateUser();
            //CreateUser(connection);
            //ReadUsers(connection);
            //ReadUser(connection);
            //ReadRoles(connection);
            //ReadTags(connection);
            ReadUsersWithRoles(connection);

            connection.Close();
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}");
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAll();

            foreach (var user in users)
                Console.WriteLine($"{user.Id} - {user.Name}");
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.GetAll();
            foreach (var role in roles)
            {
                Console.WriteLine($"{role.Id} - {role.Name}");
            }
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var tags = repository.GetAll();
            foreach (var tag in tags)
            {
                Console.WriteLine($"{tag.Id} - {tag.Name}");
            }
        }

        public static void ReadUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Get(1);
            Console.WriteLine(user.Name);
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Name = "Mauro Paiva",
                Email = "mauro@gmail.com",
                PasswordHash = "Hash",
                Bio = "Funcionário Público",
                Image = "https://",
                Slug = "mauro"
            };
            var repository = new Repository<User>(connection);
            repository.Create(user);
        }


        public static void UpdateUser(SqlConnection connection)
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

            var repository = new Repository<User>(connection);
            repository.Update(user);
        }

        public static void DeleteUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            repository.Delete(12);
        }
    }
}
