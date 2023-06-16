using BussinesLayer.Abstrack;
using BussinesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index(int page = 1)
        {
            var valu = _blogService.GetListAll().ToPagedList(page,3);
            return View(valu);
        }

        public IActionResult BlogDetails(int id)
        {

            var blog = _blogService.GetById(id);

            if (blog == null)
            {
                return NotFound();
            }

            return View("BlogDetails", blog);
        }

        public IActionResult AdminBlogList()
        {
            var blo = _blogService.GetBlogListWhiteJob();
            return View(blo);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
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
