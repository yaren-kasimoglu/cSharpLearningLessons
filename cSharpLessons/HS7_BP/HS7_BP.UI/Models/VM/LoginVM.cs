using System.ComponentModel.DataAnnotations;

namespace HS7_BP.UI.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı Adını Boş Geçemezsiniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parolayı Boş Geçemezsiniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}
