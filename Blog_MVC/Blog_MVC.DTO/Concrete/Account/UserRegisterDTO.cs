using Blog_MVC.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blog_MVC.DTO.Concrete.Account
{
    public class UserRegisterDTO : BaseDTO
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre Minimum 6 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
