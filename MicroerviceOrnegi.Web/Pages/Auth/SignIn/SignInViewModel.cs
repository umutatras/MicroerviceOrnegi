using System.ComponentModel.DataAnnotations;

namespace MicroerviceOrnegi.Web.Pages.Auth.SignIn;

public record SignInViewModel
{
    [Display(Name = "Email :")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public required string Email { get; init; }

    [Display(Name = "Password:")]
    [Required(ErrorMessage = "Password is required")]
    public required string Password { get; init; }


    public static SignInViewModel Empty => new()
    {
        Email = string.Empty,
        Password = string.Empty
    };

    public static SignInViewModel GetExampleModel => new()
    {
        Email = "umutdeneme@gmail.com",
        Password = "1234Asd**"
    };
}