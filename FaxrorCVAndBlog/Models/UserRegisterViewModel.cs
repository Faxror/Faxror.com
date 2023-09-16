using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FaxrorCVAndBlog.Models
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Ad ve Soyad")]
        [Required(ErrorMessage = "Lütfen ad ve soy ad giriniz.")]
        public string NameSurname { get; set; }


        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail adresi")]
        [Required(ErrorMessage = "Mail giriniz.")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }
    }
}
