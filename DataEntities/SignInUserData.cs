
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace DataEntities
{
    

    public class SignInUserData
    {
        [Key] 
        public Guid Id { get; set; }
        [Required(ErrorMessage = "First name required")]
        public string? FirstName { get; set; } 
    
        [Required(ErrorMessage = "Last name required")]
        public string? LastName { get; set; }
        
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage ="Use an appropriate email address")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
       
        public string? PhoneNumber { get; set; }
       
        [Required(ErrorMessage = "Password required")]
        public string? Password { get; set; } 
        public string? Course { get; set; }

       

        

    }
}
