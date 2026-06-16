using Core.UserInfo;
using Test.Models;
using Microsoft.AspNetCore.Mvc; 

namespace Test.Controllers;

public class UserInfoController(IUserInfoService userInfoService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(
            "~/Views/Home/UserInfo.cshtml",
            new UserInfoViewModel());
    }

    [HttpPost]
    public IActionResult Index(
        UserInfoViewModel model)
    {
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

        model.Plan = new MacroPlanViewModel
        {
            Calories = result.Calories,
            Protein = result.Proteins,
            Carbs = result.Carbs,
            Fat = result.Fats
        };
        Console.WriteLine($"Calories: {result.Calories}, Protein: {result.Proteins}, Carbs: {result.Carbs}, Fat: {result.Fats}");

        return View(
            "~/Views/Home/UserInfo.cshtml",
            model);
    }
}