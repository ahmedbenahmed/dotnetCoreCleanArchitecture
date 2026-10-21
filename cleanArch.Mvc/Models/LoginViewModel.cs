using System.ComponentModel.DataAnnotations;

namespace cleanArch.Mvc.Models
{
    public class LoginViewModel: IValidatableObject
    {

       

        public string UserId { get; set; }

       
        public string Password { get; set; }
        public string? RedirectUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                yield return new ValidationResult(
                    "User ID is d.",
                    new[] { nameof(UserId) });
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult(
                    "Password is required.",
                    new[] { nameof(Password) });
            }
        }
    }
}