using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
   public class CvBlogContext :  IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=89.252.187.226\\MSSQLSERVER2016; database=pekovaco_CVBLOG; user=pekovaco_admindb; password=rx5392Q@g");
            //optionsBuilder.UseSqlServer("server=DESKTOP-N4SK79N; database=CVBLOG; integrated security =true");
            optionsBuilder.UseSqlServer("server=DESKTOP-I45D279; database=CVBLOG; integrated security =true");
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
