using BussinesLayer.Abstrack;
using DataAccessLayer.Abstrack;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public List<Blog> GetBlogListWhiteAuthor()
        {
            return _blogDal.GetBlogListWhiteAuthor();
        }

        public List<Blog> GetBlogListWhiteJob()
        {
            return _blogDal.GetBlogListWhiteJob();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetListAll()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> GetListAlll(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

        public void Insert(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetAllBlogs()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetListAll();
        }

        public Blog GetBlogsWhit(int id)
        {
            var a = _blogDal.GetBlogsWhit(id);
            return a;
        }

        public List<EFBlogDal.BlogWithAuthors> GetBlogWithAuthors(int? pageNumber)
        {
            var b = _blogDal.GetBlogWithAuthors(pageNumber);
            return b;
        }
    }
}
