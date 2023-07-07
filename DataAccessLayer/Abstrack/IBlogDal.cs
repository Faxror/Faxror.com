using System;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessLayer.Concrete.EntityFramework.EFBlogDal;

namespace DataAccessLayer.Abstrack
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetBlogListWhiteJob();
        List<Blog> GetBlogListWhiteAuthor();

        Blog GetBlogsWhit(int id);

        List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber);

    }
}
