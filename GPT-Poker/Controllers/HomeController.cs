using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GPT_Poker.Models;
using LogicLayer.Core;
using LogicLayer.Models;

namespace GPT_Poker.Controllers;

public class HomeController : BaseController
{
    
    public IActionResult Index()
    {

        foreach (var unit in Core.GetUnitsInSection(new Section(1)))
        {
            Console.WriteLine("Unit " + unit.PlaceInSection + ": " + unit.Name);
        }
        
        if (!HttpContext.Session.TryGetValue("user", out _))
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        
        
        var user = HttpContext.Session.GetString("user");
        if (user == null)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        
        var account = Core.GetAccount(new Account(username: user));
        if (account == null)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        
        
        var accountViewModel = new AccountViewModel(account);
        
        
        return View(accountViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}