using DesafioApp.Models;
using DesafioApp.Repositories;
using System;

namespace DesafioApp.Screens.TagScreens
{
    public class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma Tag");
            Console.WriteLine("=================");
            Console.WriteLine("Digite o Id da Tag");
            var id = int.Parse(Console.ReadLine());
            Delete(id);
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível excluir");
                Console.WriteLine(e.Message);
            }
        }
    }
}
