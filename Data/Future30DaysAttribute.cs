using System.ComponentModel.DataAnnotations;

public class Future30DaysAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime date)
            return ValidationResult.Success;

        var today = DateTime.Today.AddDays(-2);
        if (date <= today)
            return new ValidationResult("Date must be greater than yesterday.");
        if (date > today.AddDays(30))
            return new ValidationResult("Date must be within the next 30 days.");

        return ValidationResult.Success;
    }
}
