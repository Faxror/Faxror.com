using BussinesLayer.Abstrack;
using BussinesLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;
using PagedList.Mvc;
using System;
using FaxrorCVAndBlog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static DataAccessLayer.Concrete.EntityFramework.EFBlogDal;
using Microsoft.AspNetCore.Authorization;

namespace FaxrorCVAndBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly CvBlogContext _context;
        public BlogController(IBlogService blogService,
         CvBlogContext context)
        {
            _context = context;
            _blogService = blogService;
        }
        [AllowAnonymous]
        public IActionResult Index(int? pageNumber)
        {

            var username = User.Identity.Name;
            ViewBag.veri = username;
            int page = pageNumber ?? 1;
            int pageSize = 3;
            int offset = (page - 1) * pageSize;

            try
            {
                int totalCount = _context.Blogs.Count();
                int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                // Sayfa numarasını kontrol et
                if (!pageNumber.HasValue || page < 1 || page > totalPages)
                {
                    // Geçersiz sayfa numarasına yönlendirme veya hata mesajı gönderme
                    return RedirectToAction("Index", new { pageNumber = 1 });
                }

                bool isLastPage = page == totalPages;
                ViewBag.IsLastPage = isLastPage;

                var FirstPage = 1;

                bool isFirstPage = page == FirstPage;
                ViewBag.IsFirstPage = isFirstPage;


                var paged = _blogService.GetBlogWithAuthors(pageNumber);

                PagedResult<BlogWithAuthors> pagedResult = new PagedResult<BlogWithAuthors>(paged, paged.Count, page, pageSize, totalCount);
                return View(pagedResult);
            }
            catch (Exception ex)
            {
                // Hatanın ayrıntılarını yakalayın ve hata mesajını loglayın veya gösterin
                Console.WriteLine("Hata: " + ex.Message);
                return View("Error");
            }
        }

        public class BLogWithAuthor
        {
            public Author Author { get; set; }
            public Blog Blog { get; set; }
            public Category Category { get; set; }
        }
        [AllowAnonymous]
        public IActionResult BlogDetails(int id)
        {

            var blogWithAuthor = _blogService.GetBlogsWhit(id);
            return View("BlogDetails", blogWithAuthor);

        }
 
        public IActionResult AdminBlogList()
        {
           
          
            var blo2 = _blogService.GetBlogListWhiteJob();
            return View(blo2);
        }


        public IActionResult AuthorBlogList()
        {


            var blo2 = _blogService.GetBlogListWhiteJob();
            return View(blo2);
        }
        [HttpGet]
        public IActionResult AuthorAddBlog()
        {
            AuthorManager bookManager = new AuthorManager(new EFAuthorDal());
            List<SelectListItem> values = (from x    in bookManager.GetListAll()
                                           select new SelectListItem
                                           {

                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            List<SelectListItem> valuess = (from x in categoryManager.GetListAll()
                                           select new SelectListItem
                                           {

                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.s = valuess;
            return View();
        }
        [HttpPost]
        public IActionResult AuthorAddBlog(Blog p)
        {

            _blogService.Insert(p);
            return RedirectToAction("AuthorBlogList");
        }

        [HttpGet]
        public IActionResult AuthorAddUpdate(int id)
        {
            AuthorManager bookManager = new AuthorManager(new EFAuthorDal());
            List<SelectListItem> values = (from x in bookManager.GetListAll()
                                           select new SelectListItem
                                           {

                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            List<SelectListItem> valuess = (from x in categoryManager.GetListAll()
                                            select new SelectListItem
                                            {

                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.s = valuess;
            var value = _blogService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult AuthorAddUpdate(Blog p)
        {
            _blogService.Update(p);
            return RedirectToAction("AuthorBlogList");
        }
        public IActionResult AuthorDeleteBlog(int id)
        {
            var value = _blogService.GetById(id);
            _blogService.Delete(value);
            return RedirectToAction("AuthorBlogList");
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            AuthorManager bookManager = new AuthorManager(new EFAuthorDal());
            List<SelectListItem> values = (from x in bookManager.GetListAll()
                                           select new SelectListItem
                                           {

                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            List<SelectListItem> valuess = (from x in categoryManager.GetListAll()
                                            select new SelectListItem
                                            {

                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.s = valuess;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog p)
        {

            _blogService.Insert(p);
            return RedirectToAction("AdminBlogList");
        }

        [HttpGet]
        public IActionResult AddUpdate(int id)
        {
            AuthorManager bookManager = new AuthorManager(new EFAuthorDal());
            List<SelectListItem> values = (from x in bookManager.GetListAll()
                                           select new SelectListItem
                                           {

                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.v = values;

            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            List<SelectListItem> valuess = (from x in categoryManager.GetListAll()
                                            select new SelectListItem
                                            {

                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();
            ViewBag.s = valuess;
            var value = _blogService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult AddUpdate(Blog p)
        {
            _blogService.Update(p);
            return RedirectToAction("AdminBlogList");
        }
        public IActionResult DeleteBlog(int id)
        {
            var value = _blogService.GetById(id);
            _blogService.Delete(value);
            return RedirectToAction("AdminBlogList");
        }
    }
}
