using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Password { get; set; }
    }
}
