﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J_uan.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
