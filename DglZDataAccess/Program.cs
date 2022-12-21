using Dapper;
using DglZDataAccess.Models;
using Microsoft.Data.SqlClient;
using System;

namespace DglZDataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=DglZ;User ID=sa;Password=2w3e4r5t!@#;TrustServerCertificate=true";

            using (var connection = new SqlConnection(connectionString))
            {
                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} - {category.Title}");
                }
            }
        }
    }
}
