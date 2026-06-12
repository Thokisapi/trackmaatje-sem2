using System.ComponentModel.DataAnnotations;
namespace Test.Models;
public class LoginViewModel
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}