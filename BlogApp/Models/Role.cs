using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace BlogApp.Models
{
    [Table("[Role]")]
    public class Role
    {
        //public Role()
        //{
        //    UserId = new List<User>();
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        //public List<User> UserId { get; set; }
    }
}
