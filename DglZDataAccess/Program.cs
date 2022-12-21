using Dapper;
using DglZDataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DglZDataAccess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=DglZ;User ID=sa;Password=2w3e4r5t!@#;TrustServerCertificate=true";

            using (var connection = new SqlConnection(connectionString))
            {
                //UpdateCategory(connection);
                //CreateManyCategory(connection);
                //ListCategories(connection);
                //CreateCategory(connection);
                //ExecuteProcedure(connection);
                ExecuteReadProcedure(connection);
            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }
        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Title = "Amazon AWS",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 8,
                Summary = "AWS Cloud",
                Featured = false
            };

            var insertSql = @"INSERT INTO 
                                [Category] 
                            VALUES (
                                @Id, 
                                @Title, 
                                @Url, 
                                @Summary, 
                                @Order, 
                                @Description, 
                                @Featured)";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"{rows} linhas inseridas");
        }
        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title]=@title WHERE [Id]=@id";
            var rows = connection.Execute(updateQuery, new
            {
                Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                Title = "Frontend 2021"
            });
            Console.WriteLine($"{rows} registros atualizadas");
        }
        static void CreateManyCategory(SqlConnection connection)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Title = "Amazon AWS",
                Url = "amazon",
                Description = "Categoria destinada a serviços do AWS",
                Order = 8,
                Summary = "AWS Cloud",
                Featured = false
            };
            var category2 = new Category()
            {
                Id = Guid.NewGuid(),
                Title = "Categoria Nova",
                Url = "categoria-nova",
                Description = "Categoria nova",
                Order = 9,
                Summary = "Categoria",
                Featured = true
            };

            var insertSql = @"INSERT INTO 
                                [Category] 
                            VALUES (
                                @Id, 
                                @Title, 
                                @Url, 
                                @Summary, 
                                @Order, 
                                @Description, 
                                @Featured)";

            var rows = connection.Execute(insertSql, new[]
            {
                new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new
                {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                }
            });
            Console.WriteLine($"{rows} linhas inseridas");
        }
        static void ExecuteProcedure(SqlConnection connection)
        {
            var procedure = "[sp_DeleteStudent]";
            var prms = new
            {
                StudentId = "af4e3c82-2d76-460b-ae58-aa62ec86ecc1"
            };
            var affectedRows = connection.Execute(procedure, prms, commandType: CommandType.StoredProcedure);
            Console.WriteLine($"{affectedRows} linhas afetadas");
        }
        static void ExecuteReadProcedure(SqlConnection connection)
        {
            var procedure = "sp_GetCoursesByCategory";
            var prms = new
            {
                CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142"
            };

            var courses = connection.Query(procedure, prms, commandType: CommandType.StoredProcedure);
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Id} - {course.Title}");
            }
        }
    }
}
