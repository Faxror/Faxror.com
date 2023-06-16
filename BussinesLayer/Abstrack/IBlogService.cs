using DataAccessLayer.Abstrack;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstrack
{
    public  interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogListWhiteJob();


        List<Blog> GetListAlll(int id);
       
    }
}
