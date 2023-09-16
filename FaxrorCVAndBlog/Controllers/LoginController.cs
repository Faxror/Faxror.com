using DataAccessLayer.Context;
using EntityLayer.Concrete;
using FaxrorCVAndBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _singInManager;

        public LoginController(SignInManager<AppUser> singInManager)
        {
            _singInManager = singInManager;
        }

        [HttpGet]
        public IActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> AuthorLogin(UserLoginViewModel p)
        {
            if(ModelState.IsValid) { 
            var result = await _singInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("AuthorBlogList", "Blog");
                }
                else
                {
                    return RedirectToAction("AuthorLogin", "Login");
                }
            }
            return View();
        }
    }
}
