using Core.Users;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class RegisterController(IUserService userService) : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Home/Register.cshtml", new CreateUserViewModel());
        }

        [HttpPost]
        public IActionResult Register(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/Register.cshtml", model);
            }
            
            var request = new CreateUserRequest(model.Name, model.Email, model.Password);
            userService.CreateUser(request);

            return RedirectToAction("Login");
        }


    }
}
