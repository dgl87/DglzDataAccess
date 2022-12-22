using System.Collections.Generic;

namespace BlogApp.Models
{
    public class Tag
    {
        public Tag()
        {
            PostId = new List<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<Post> PostId { get; set; }
    }
}
