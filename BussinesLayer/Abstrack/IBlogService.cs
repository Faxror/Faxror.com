using DataAccessLayer.Abstrack;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Concrete.EntityFramework.EFBlogDal;

namespace BussinesLayer.Abstrack
{
    public  interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogListWhiteJob();

        List<Blog> GetBlogListWhiteAuthor();

        List<Blog> GetListAlll(int id);

        Blog GetBlogsWhit(int id);

        List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber);

    }
}
