using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MyPersonalDemo.Models;

namespace MyPersonalDemo.CustomValidators
{
    public class PasswordValidate : ValidationAttribute
    {
        public string OtherPropertyName;

        public PasswordValidate(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext vcxt)
        {


            if (value != null)
            {
                string passwordl = Convert.ToString(value);
                PropertyInfo? otherprop = vcxt.ObjectType.GetProperty(OtherPropertyName);

                if (otherprop != null)
                {
                    string password = Convert.ToString(otherprop.GetValue(vcxt.ObjectInstance));
                    if (password != passwordl)
                    {
                        return new ValidationResult("Password mismatch");
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
