using System.ComponentModel.DataAnnotations;
namespace quotingdojo3.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Names cannot contain numbers.")]
        public string first_name { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Names cannot contain numbers.")]
        public string last_name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Compare("password", ErrorMessage = "Password and confirmation must match.")]
        public string confirm_password { get; set; }
    }
}