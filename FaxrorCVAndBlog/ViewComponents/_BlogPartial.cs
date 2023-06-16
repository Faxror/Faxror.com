using BussinesLayer.Abstrack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog.ViewComponents
{
    public class _BlogPartial: ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogPartial(IBlogService blogService)
        {
            _blogService = blogService;
        }

       
        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetBlogListWhiteJob();
            return View(values);
        }
    }
}
