using System.ComponentModel.DataAnnotations;

namespace ConcertBooking.UI.Validations
{
    public class UppercaseAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, 
            ValidationContext validationContext)
        {
            if (value != null) 
            {
                string stringValue = value.ToString();
                if(!string.IsNullOrEmpty(stringValue))
                {
                    char firstLetter = stringValue[0];
                    if(char.IsUpper(firstLetter))
                    {
                        return ValidationResult.Success;
                    }
                }
            }
            return new ValidationResult(ErrorMessage ?? "The First Letter must be in Uppercase");
        }
    }
}
