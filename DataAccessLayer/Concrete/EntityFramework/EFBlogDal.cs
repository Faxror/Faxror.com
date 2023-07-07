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

        private readonly CvBlogContext _context;

        public EFBlogDal(CvBlogContext context)
        {
            _context = context;
        }

        public List<Blog> GetBlogListWhiteJob()
        {
            using (var c = new CvBlogContext())
            {
                return c.Blogs.Include(x => x.Category).Include(x => x.Author).ToList();
            }

        }

        public List<Blog> GetBlogListWhiteAuthor()
        {
            using (var c = new CvBlogContext())
            {
                return c.Blogs.Include(x => x.Author).ToList();
            }
        }

        public List<BlogWithAuthors> GetBlogWithAuthors(int? pageNumber)
        {
            int page = pageNumber ?? 1;
            int pageSize = 3;
            int offset = (page - 1) * pageSize;

            var blogs = _context.Blogs
                     .OrderBy(b => b.BlogID)
                     .Skip(offset)
                     .Take(pageSize).Join(_context.Authors.AsNoTracking(),
                     blog => blog.AuthorID,
                     author => author.AuthorID,
                     (blog, author) => new  BlogWithAuthors{ Author = author, Blog = blog }).ToList();

            return blogs;



        }

        public class BlogWithAuthors {

            public Blog Blog { get; set; }
            public Author Author { get; set; }

        }

        public Blog GetBlogsWhit(int id)
        {
            var blogWithAuthorAndCategory = _context.Blogs
                  .Join(
                      _context.Authors.AsNoTracking(),
                      blog => blog.AuthorID,
                      author => author.AuthorID,
                      (blog, author) => new { Author = author, Blog = blog })
                  .Join(
                      _context.Categories.AsNoTracking(),
                      blogWithAuthor => blogWithAuthor.Blog.CategoryID,
                      category => category.CategoryID,
                      (blogWithAuthor, category) => new { Author = blogWithAuthor.Author, Blog = blogWithAuthor.Blog, Category = category })
                  .FirstOrDefault(b => b.Blog.BlogID == id);

            if (blogWithAuthorAndCategory!= null)
            {
                Blog blog = new Blog()
                {
                    Author = blogWithAuthorAndCategory.Author,
                    AuthorID = blogWithAuthorAndCategory.Author.AuthorID,
                    BlogContent = blogWithAuthorAndCategory.Blog.BlogContent,
                    BlogID = blogWithAuthorAndCategory.Blog.BlogID,
                    BlogImage = blogWithAuthorAndCategory.Blog.BlogImage,
                    BlogTime = blogWithAuthorAndCategory.Blog.BlogTime,
                    BlogTıtle = blogWithAuthorAndCategory.Blog.BlogTıtle,
                    Category = blogWithAuthorAndCategory.Category,
                    CategoryID = blogWithAuthorAndCategory.Blog.CategoryID
                };


                return blog;
            }

            return null;
        }
    }
}
