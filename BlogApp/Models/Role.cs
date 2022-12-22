using System.Collections.Generic;

namespace BlogApp.Models
{
    public class Role
    {
        public Role()
        {
            UserId = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<User> UserId { get; set; }
    }
}
