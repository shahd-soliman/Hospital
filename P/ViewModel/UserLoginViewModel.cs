using System.ComponentModel.DataAnnotations;

namespace P.ViewModel
{
    public class UserLoginViewModel
    {

        [Required]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
