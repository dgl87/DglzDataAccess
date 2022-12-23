using System;
using System.Collections.Generic;

namespace BlogApp.Models
{
    public class Category
    {
        public Category()
        {
            Posts = new List<Post>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Post> Posts { get; set; }
    }
}
