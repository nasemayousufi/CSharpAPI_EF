using System.ComponentModel.DataAnnotations;

namespace FinalProject1.Models
{
    public class Dress_EnsureCorrectSizingAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var dress = validationContext.ObjectInstance as Dress;
            if (dress != null && !string.IsNullOrWhiteSpace(dress.Gender))
            {
                if
                    (dress.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && dress.Size < 4)
                {
                    return new ValidationResult("For women's dresses,the size has to be greater or equal to 4.");
                }

            }
            return ValidationResult.Success;



        }
    }

}

    

