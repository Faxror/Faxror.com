using BussinesLayer.Abstrack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog.ViewComponents
{
    public class _PartialDetails: ViewComponent
    {
        private readonly IBlogService _blogService;

        public _PartialDetails(IBlogService blogService)
        {
            _blogService = blogService;
        }
        

        public IViewComponentResult Invoke()
        {
            var ı = _blogService.GetBlogListWhiteJob();
            return View(ı);
        }
     
    }
}
