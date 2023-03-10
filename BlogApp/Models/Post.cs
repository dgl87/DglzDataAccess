using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace BlogApp.Models
{
    [Table("[Post]")]
    public class Post
    {
        public Post()
        {
            TagId = new List<Tag>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<Tag> TagId { get; set; }
    }
}
