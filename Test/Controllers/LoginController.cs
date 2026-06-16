using Core.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers;

public class LoginController : Controller
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(
            "~/Views/Home/Login.cshtml",
            new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(
                "~/Views/Home/Login.cshtml",
                model);
        }
        var request = new LoginUserRequest(
            model.Email,
            model.Password);
        var user = _userService.Login(request);

        if (user == null)
        {
            ModelState.AddModelError(
                "",
                "Invalid email or password");

            return View(
                "~/Views/Home/Login.cshtml",
                model);
        }

        HttpContext.Session.SetString(
            "UserEmail",
            user.Email);
        Console.WriteLine($"{user.Email}");

        return RedirectToAction(
            "Userinfo",
            "Home");
    }
}