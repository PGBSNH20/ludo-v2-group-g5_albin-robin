using System.ComponentModel.DataAnnotations;

namespace LudoAPI.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Account name is required")]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        


    }
}
