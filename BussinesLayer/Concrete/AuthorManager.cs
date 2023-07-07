using BussinesLayer.Abstrack;
using DataAccessLayer.Abstrack;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void Delete(Author t)
        {
            _authorDal.Delete(t);
        }

        public Author GetById(int id)
        {
            return _authorDal.GetById(id);
        }

        public List<Author> GetListAll()
        {
          return _authorDal.GetListAll();
        }

        public void Insert(Author t)
        {
            _authorDal.Insert(t);
        }

        public void Update(Author t)
        {
            _authorDal.Update(t);
        }
    }
}
