using System.ComponentModel.DataAnnotations;
using DataEntities;

namespace MyPersonalDemo.CustomValidators
{
    public class EmailValidator:ValidationAttribute
    {
        private DataBase? _db;

        public EmailValidator(DataBase? db)
        {
            _db = db;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            if (_db.Users.Where(e => e.Email == Convert.ToString(value)).Any())
            {
                return new ValidationResult("Email Alraedy Exists.");
            }
            return ValidationResult.Success;
           
        }


    }
}
