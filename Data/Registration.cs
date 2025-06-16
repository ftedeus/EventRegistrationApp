using System.ComponentModel.DataAnnotations;

namespace EventRegistrationApp.Data;

public class Registration
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = "";

       public bool IsAttended { get; set; }
}