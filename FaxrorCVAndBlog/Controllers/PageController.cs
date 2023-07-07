using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using System;

using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Threading.Tasks;

namespace FaxrorCVAndBlog.Controllers
{
    public class PageController : Controller
    {

        private readonly CvBlogContext _context;
        public PageController(CvBlogContext context)
        {
            _context = context;
                    }
       
   
        public IActionResult Index()
        {
            return View();
        }

    }
}
