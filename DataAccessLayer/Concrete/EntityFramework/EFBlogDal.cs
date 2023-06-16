using DataAccessLayer.Abstrack;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetBlogListWhiteJob()
        {
            using (var c = new CvBlogContext())
            {
                return c.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}
