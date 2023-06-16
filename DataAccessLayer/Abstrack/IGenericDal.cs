using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstrack
{
    public interface IGenericDal<T> where T : class, new()
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);

        T GetById(int id);

        List<T> GetListAll();
        List<T> GetListAll(Expression<Func<T, bool>> where);
    }
}
