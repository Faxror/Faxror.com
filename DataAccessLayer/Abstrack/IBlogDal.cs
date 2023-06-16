using System;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstrack
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetBlogListWhiteJob();
    }
}
