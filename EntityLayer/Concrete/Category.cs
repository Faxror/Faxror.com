﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}

//Eksikler
// Admin Login
// Populer Konular
// Yeni Konular
// Ana Sayfa ya çeki düzen verme