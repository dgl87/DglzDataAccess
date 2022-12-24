using DesafioApp.Models;
using DesafioApp.Repositories;
using System;

namespace DesafioApp.Screens.TagScreens
{
    public class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma Tag");
            Console.WriteLine("===================");
            Console.WriteLine("Digite o Id da Tag");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome da Tag: ");
            var name = Console.ReadLine();
            Console.Write("Digite o Slug da Tag: ");
            var slug = Console.ReadLine();
            Update(new Tag
            {
                Id = id,
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        private static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível atualizar");
                Console.WriteLine(e.Message);
            }
        }
    }
}
