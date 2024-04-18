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
    
    
    public IActionResult LoginPost(string username, string password)
    {
        var player = Core.GetPlayer(new Player(0, username: username));

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
}