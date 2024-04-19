using LogicLayer;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace GPT_Poker.Controllers;

public class LoginController : BaseController
{
    
    public IActionResult Index()
    {
        ViewData["login-error"] = TempData["login-error"];
        
        return View();
    }
    
    public IActionResult SignIn()
    {
        ViewData["signin-error"] = TempData["signin-error"];
        
        return View();
    }
    
    
    public IActionResult LoginPost(string identifier, string password)
    {
        var player = Core.GetAccount(identifier.Contains('@') ? new Account(0, email: identifier) : new Account(0, username: identifier));


        if (player == null)
        {
            TempData["login-error"] = "Account not found";
            
            return RedirectToAction("Index");
        }
        
        if (!Core.ValidateCredentials(player, password))
        {
            TempData["login-error"] = "Incorrect Password";
            
            return RedirectToAction("Index");
        }
        
        HttpContext.Session.SetString("user", player.Username);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult SignInPost(string username, string email, string password)
    {
        //check format the email to remove dots before the '@'
        email = Core.FormatEmail(email);
        
        //check if the email is valid
        if (!Core.IsValidEmail(email))
        {
            TempData["signin-error"] = "Invalid Email";
            return RedirectToAction("SignIn", "Login");
        }
        
        
        //check if the username is valid
        var usernameValidity = Core.IsValidUsername(username);
        
        if (!usernameValidity.valid)
        {
            TempData["signin-error"] = usernameValidity.message;
            return RedirectToAction("SignIn", "Login");
        }
        
        
        
        var player = new Account(0, username, email, password, 5);

        var result = Core.AddAccount(player);
        
        switch (result)
        {
            case Core.Result.Success:
                HttpContext.Session.SetString("user", player.Username);
                return RedirectToAction("Index", "Home");
            
            case Core.Result.Duplicate:
                TempData["signin-error"] = Core.AccountExists(new Account(0, username: username))
                    ? "Username is already in use"
                    : "Email is already in use";
                return RedirectToAction("SignIn", "Login");

            case Core.Result.Fail:
            default:
                TempData["signin-error"] = "Failed to create account";
                return RedirectToAction("SignIn", "Login");
        }
    }
}