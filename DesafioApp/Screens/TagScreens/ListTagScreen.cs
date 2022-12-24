﻿using DesafioApp.Models;
using DesafioApp.Repositories;
using System;

namespace DesafioApp.Screens.TagScreens
{
    public class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Tags");
            Console.WriteLine("=============");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.GetAll();
            foreach (var tag in tags)
            {
                Console.WriteLine($"{tag.Id} - {tag.Name} ({tag.Slug})");
            }
        }
    }
}
