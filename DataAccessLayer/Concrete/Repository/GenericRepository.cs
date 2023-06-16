using DataAccessLayer.Abstrack;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Delete(T t)
        {
            using var c = new CvBlogContext();
            c.Set<T>().Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new CvBlogContext();
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var c = new CvBlogContext();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var c = new CvBlogContext();
            c.Set<T>().Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> where)
        {
            using var c = new CvBlogContext();
            return c.Set<T>().Where(where).ToList();
        }

        public void Update(T t)
        {
            using var c = new CvBlogContext();
            c.Set<T>().Update(t);
            c.SaveChanges();
        }
    }
}
