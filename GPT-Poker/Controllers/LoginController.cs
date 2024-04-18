using LogicLayer;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace GPT_Poker.Controllers;

public class LoginController : BaseController
{
    
    public IActionResult Index()
    {
        ViewData["error"] = TempData["error"];
        
        return View();
    }
    
    
    public IActionResult LoginPost(string username, string password)
    {
        var player = Core.GetPlayer(new Player(0, username: username));

        if (player == null)
        {
            TempData["error"] = "Username not found";
            
            return RedirectToAction("Index");
        }
        
        
        
        if (!Core.ValidCredentials(player, password))
        {
            TempData["error"] = "Wrong password";
            
            return RedirectToAction("Index");
        }
        else
        {
            HttpContext.Session.SetString("user", player.Username);
        }

        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("user");
        return RedirectToAction("Index");
    }
}