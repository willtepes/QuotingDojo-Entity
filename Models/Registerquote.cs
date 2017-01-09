using System.ComponentModel.DataAnnotations;
namespace quotingdojo3.Models
{
    public class Registerquote : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string quote { get; set; }
    }
}