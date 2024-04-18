using System.Text.RegularExpressions;
using LogicLayer;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace GPT_Poker.Controllers;

public partial class LoginController : BaseController
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
        var player = Core.GetPlayer(identifier.Contains('@') ? new Player(0, email: identifier) : new Player(0, username: identifier));


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
        
        //check if the email is valid
        if (!Core.IsValidEmail(email)) 
        {
            TempData["signin-error"] = "Invalid Email";
            return RedirectToAction("SignIn", "Login");
        }
        
        //remove all dots from the email before the '@' and make the email lowercase
        email = string.Concat(email[..email.IndexOf('@')].Replace(".", ""), email.AsSpan(email.IndexOf('@'))).ToLower();
        
        
        //check if the username is valid
        if (username.Length is < 5 or > 20)
        {
            TempData["signin-error"] = "Username must be between 5 and 20 characters";
            return RedirectToAction("SignIn", "Login");
        }
        
        //check if the username is alphanumeric
        if (!UsernameRegex().IsMatch(username))
        {
            TempData["signin-error"] = "Username can only contain letters and numbers";
            return RedirectToAction("SignIn", "Login");
        }
        
        //check if the username starts with a letter
        if (!char.IsLetter(username[0]))
        {
            TempData["signin-error"] = "Username must start with a letter";
            return RedirectToAction("SignIn", "Login");
        }
        
        
        
        
        var player = new Player(0, username, email, password, 5);

        var result = Core.AddPlayer(player);
        
        var message = result switch
        {
            Core.Result.Succes => "Account Created!",
            Core.Result.Duplicate => "Email or Username is already in use",
            _ => "Failed to create account"
        };
        
        TempData["signin-error"] = message;
        
        if (result == Core.Result.Succes)
        {
            TempData["signin-error"] = "";
            
            HttpContext.Session.SetString("user", player.Username);
            return RedirectToAction("Index", "Home");
        }
        
        return RedirectToAction("SignIn", "Login");
    }

    [GeneratedRegex("^[a-zA-Z0-9]+$")]
    private static partial Regex UsernameRegex();
}