using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Helpers;

namespace Test.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Userinfo()
    {
        // Check if user is logged in
        var redirectResult = this.RedirectToLoginIfNotLoggedIn();
        if (redirectResult != null) return redirectResult;

        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View(new CreateUserViewModel());
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}