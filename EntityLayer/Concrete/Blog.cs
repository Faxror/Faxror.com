﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogID { get; set; }
        public string BlogTıtle { get; set; }

        public string BlogImage { get; set; }
        public DateTime BlogTime { get; set; }

        public string BlogContent { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
    }
}
