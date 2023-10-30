using Microsoft.AspNetCore.Mvc;
using DataEntities;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using MyPersonalDemo.CustomValidators;

namespace MyPersonalDemo.Models
{
    

    public class SignInUserDataActive:IValidatableObject
    {
        private static DataBase _database;
        
       public void SetDB(DataBase database)
        {
            _database = database;
        }

        [BindProperty]
        [Required(ErrorMessage = "First name required")]
        public string? FirstName { get; set; } 
        [BindProperty]
        [Required(ErrorMessage = "Last name required")]
        public string? LastName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Email required2")]
        [EmailAddress(ErrorMessage ="Use an appropriate email address")]
        [DataType(DataType.EmailAddress)]
       
        public string? Email { get; set; }
        [BindProperty]
        public string? PhoneNumber { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Password required")]
        public string? Password { get; set; }
        
        
        [PasswordValidate("Password")]
        [Required(ErrorMessage ="Enter password")]
        
        public string? PasswordL { get; set; }
       
        
        [BindProperty]
        
        public string? Course { get; set; }

        public LogInUserDataActive? ToLoginUser()
        {
            if(Email!=null && PasswordL != null)
            {
                return new LogInUserDataActive()
                {
                    Email = Email,
                    Password = PasswordL,
                };
               
            } 
            return null;
        }

        public SignInUserData ToUserData()
        {
            return new SignInUserData()
            {
                Id=Guid.NewGuid(),
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                PhoneNumber = PhoneNumber,
                Course = Course,
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Email== null)
            {
                yield return null;
            }
            if (_database.Users.Where(e => e.Email == Email).Any())
            {
               yield  return new ValidationResult("Email Already Exists.", new[] { nameof(Email) });
            }
           yield return ValidationResult.Success;

        }
    }
}
