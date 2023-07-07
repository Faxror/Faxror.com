using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AuthorLogin(Author p)
        {


            return View();
        }
    }
}
