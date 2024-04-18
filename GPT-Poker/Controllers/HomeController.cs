using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GPT_Poker.Models;
using LogicLayer;

namespace GPT_Poker.Controllers;

public class HomeController : BaseController
{
    
    public IActionResult Index()
    {
        var view = View();
        
        
        var accounts = Core.GetAllAccounts();
        
        view.ViewData["accounts"] = accounts;
        

        return view;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}