using System.ComponentModel.DataAnnotations;

namespace Fitness_Diet_Reviewer.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        [Required]
        public int Age { get; set; }
        [Required]
        public decimal Height { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
