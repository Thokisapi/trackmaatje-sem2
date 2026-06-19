using Core.UserInfo;
using Test.Models;
using Core.Users;
using Microsoft.AspNetCore.Mvc;
using Test.Helpers;

namespace Test.Controllers;

public class UserInfoController(   IUserInfoService userInfoService,IUserService userService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        // Check if user is logged in
        var redirectResult = this.RedirectToLoginIfNotLoggedIn();
        if (redirectResult != null) return redirectResult;

        return View(
            "~/Views/Home/UserInfo.cshtml",
            new UserInfoViewModel());
    }

    [HttpPost]
    public IActionResult Index(
        UserInfoViewModel model)
    {
        // Check if user is logged in
        var redirectResult = this.RedirectToLoginIfNotLoggedIn();
        if (redirectResult != null) return redirectResult;

        if (!ModelState.IsValid)
            return View(
                "~/Views/Home/UserInfo.cshtml",
                model);

        var request = new UserInfoRequest(
            model.Weight,
            model.Height,
            model.Age,
            model.Gender,
            model.ActivityLevel,
            model.Goal);

        var result =
            userInfoService.Calculate(request);
        
        var email = HttpContext.GetUserEmail();
        
        if (string.IsNullOrEmpty(email))
        {
            return RedirectToAction("Login", "Login");
        }

        var user =
            userService.GetUserByEmail(
                email);

        if (user == null)
        {
            return RedirectToAction(
                "Login",
                "Login");
        }
        userInfoService.SaveUserInfo(
            new SaveUserInfoRequest
            {
                UserId = user.Id,
                Age = model.Age,
                Weight = model.Weight,
                Gender = model.Gender,
                Height = model.Height,
                GoalCalories = result.Calories,
                GoalCarbs = result.Carbs,
                GoalProtein = result.Proteins,
                GoalFat = result.Fats
            });

        model.Plan = new MacroPlanViewModel
        {
            Calories = result.Calories,
            Protein = result.Proteins,
            Carbs = result.Carbs,
            Fat = result.Fats
        };
        return View(
            "~/Views/Home/UserInfo.cshtml",
            model);
    }
}