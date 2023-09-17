using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult Page404()
        {
         
            return View();
        }

        [Route("Error/500")]
        public IActionResult Page500()
        {
        try
        {
            throw new Exception("Bu bir örnek istisna.");

        }
        catch (Exception ex)
        {
            // Hata işleme kodlarını burada yerine getirin
            // Örneğin, hatayı bir günlüğe kaydetme, istisna mesajını görüntüleme vb.
            
            return View();
        }



        }
        [Route("Error/403")]
        public IActionResult Page403( )
        {
            return View();
        }

        [Route("Error/408")]
        public IActionResult Page408()
        {
            return View();
        }


    }

}
