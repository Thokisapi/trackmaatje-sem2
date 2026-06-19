using System.ComponentModel.DataAnnotations;

namespace Test.Models;

public class UserInfoViewModel
{
    [Required]
    public float Weight { get; set; }

    [Required]
    public int Height { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public string Gender { get; set; } = string.Empty;

    [Required]
    public string ActivityLevel { get; set; } = string.Empty;

    [Required]
    public string Goal { get; set; } = string.Empty;

    public MacroPlanViewModel? Plan { get; set; }
}