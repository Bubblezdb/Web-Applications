﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI.Models
{
    public partial class Category
    {
        public Category() { Post = new HashSet<Post>(); }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}
