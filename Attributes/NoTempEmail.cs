using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Attributes;

public class NoTempEmail: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Email is required.");
        }

        var email = value.ToString();
        var tempEmailDomains = new List<string>
        {
            "tempmail.com",
            "10minutemail.com",
            "mailinator.com",
            "guerrillamail.com",
            "throwawaymail.com",
            "mail.tm",
            "mail.gw"
        };

        if (email != null && tempEmailDomains.Any(domain => email.EndsWith("@" + domain)))
        {
            return new ValidationResult("Temporary email addresses are not allowed.");
        }

        return ValidationResult.Success;
    }
}