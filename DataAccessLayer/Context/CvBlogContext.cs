using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
   public class CvBlogContext :  DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=104.247.167.130\\MSSQLSERVER2016; database=pekovaco_CVBLOG; user=pekovaco_admindb; password=rx5392Q@g");
        }


        //public void GenerateListData()
        //{
        //    _ = Blogs.Add(new Blog { BlogID = 3 , BlogTıtle = "John", BlogImage = "Doe", BlogTime = DateTime.Now, BlogContent = "fdfsdfsagfagsfs", CategoryID = 1 });
        //    SaveChanges();
        //}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author>  Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
