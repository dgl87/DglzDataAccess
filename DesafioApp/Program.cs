using DesafioApp.Models;
using DesafioApp.Repositories;
using DesafioApp.Screens.TagScreens;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioApp
{
    internal class Program
    {
        private const string STRING_CONNECTION = "Server=localhost,1433;Database=Blog;User ID=sa;Password=2w3e4r5t!@#;TrustServerCertificate=true";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(STRING_CONNECTION);
            Database.Connection.Open();
            Load();
            //ReadUsers(connection);

            Console.ReadKey();
            Database.Connection.Close();
        }
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAll();
            foreach (var user in users)
            {
                System.Console.WriteLine($"{user.Id} - {user.Name}");
            }
        }
        private static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("==================");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Usuário");
            Console.WriteLine("2 - Gestão de Perfil");
            Console.WriteLine("3 - Gestão de Categoria");
            Console.WriteLine("4 - Gestão de Tag");
            Console.WriteLine("5 - Vincular Perfil / Usuário");
            Console.WriteLine("6 - Vincular Post / Tags");
            Console.WriteLine("7 - Relatórios");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 4:
                    MenuTagScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}
