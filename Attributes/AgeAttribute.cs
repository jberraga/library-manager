using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Attributes;

public class AgeAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext? context)
    {
        if (value == null)
        {
            return new ValidationResult("Age is required.");
        }
        
        var age = (int)value;
        
        return age is >= 12 and <= 150 ? ValidationResult.Success : new ValidationResult("Age must be between 12 and 150.");
    }
}