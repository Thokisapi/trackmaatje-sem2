using Microsoft.AspNetCore.Mvc;

namespace Test.Helpers;

public static class AuthHelper
{
    public static bool IsUserLoggedIn(this HttpContext httpContext)
    {
        var userEmail = httpContext.Session.GetString("UserEmail");
        return !string.IsNullOrEmpty(userEmail);
    }
    
    public static string? GetUserEmail(this HttpContext httpContext)
    {
        return httpContext.Session.GetString("UserEmail");
    }
    
    public static IActionResult? RedirectToLoginIfNotLoggedIn(this Controller controller)
    {
        if (!controller.HttpContext.IsUserLoggedIn())
        {
            return controller.RedirectToAction("Login", "Login");
        }
        return null;
    }
}

