﻿using Dapper.Contrib.Extensions;

namespace DesafioApp.Models
{
    [Table("[Tag]")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
