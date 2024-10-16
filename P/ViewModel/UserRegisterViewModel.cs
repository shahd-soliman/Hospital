using System.ComponentModel.DataAnnotations;

namespace P.ViewModel
{
    public class UserRegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public int age { get; set; }
        public string phone { get; set; }

        public string Address { get; set; }
        public int Age { get; set; }
    }
}
