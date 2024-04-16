using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GPT_Poker.Models;
using LogicLayer;
using LogicLayer.Models;

namespace GPT_Poker.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

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