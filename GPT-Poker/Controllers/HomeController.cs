using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GPT_Poker.Models;
using LogicLayer;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GPT_Poker.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!HttpContext.Session.TryGetValue("user", out _))
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "Login" },  
                { "action", "Index" }  
            });  
        }
        
        base.OnActionExecuting(context);
    }
    
    
    
    public IActionResult Index()
    {
        var view = View();
        
        
        var players = Core.GetAllPlayers();
        
        view.ViewData["players"] = players;
        

        return view;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}