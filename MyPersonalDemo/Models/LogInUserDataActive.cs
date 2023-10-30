using System.ComponentModel.DataAnnotations;

namespace MyPersonalDemo.Models
{
    public class LogInUserDataActive
    {
        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password required")]
        public string Password { get; set; }
    }
}
