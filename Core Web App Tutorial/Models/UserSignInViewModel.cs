using System.ComponentModel.DataAnnotations;

namespace Core_Web_App_Tutorial.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Girin.")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Şifrenizi Girin.")]
        public string? Password { get; set; }
    }
}
