using DesafioApp.Models;
using DesafioApp.Repositories;
using System;

namespace DesafioApp.Screens.TagScreens
{
    public class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Tag");
            Console.WriteLine("=============");
            Console.Write("Digite o Nome da Tag: ");
            var name = Console.ReadLine();
            Console.Write("Digite o Slug da Tag: ");
            var slug = Console.ReadLine();
            Create(new Tag
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        private static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag cadastrada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("O Slug informado já existe");
                Console.WriteLine(e.Message);
            }            
        }
    }
}
