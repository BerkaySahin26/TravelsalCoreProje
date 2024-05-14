using System.ComponentModel.DataAnnotations;

namespace TravelsalCoreProje.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string password { get; set; }

    }
}
