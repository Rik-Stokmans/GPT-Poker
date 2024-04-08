using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GPT_Poker.Models;
using LogicLayer;
using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace GPT_Poker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDatabaseEntityService<Player> _playerService;
    
    public HomeController(ILogger<HomeController> logger, IDatabaseEntityService<Player> playerService)
    { 
        _logger = logger;
        _playerService = playerService;
    }

    public IActionResult Index()
    { 

        
        var player = _playerService.GetFromKey(new Player(15)).GetAwaiter().GetResult();

        if (player != null)
        {
            Console.WriteLine(player.Id);
            Console.WriteLine(player.Username);
            Console.WriteLine(player.Email);
            Console.WriteLine(player.Password);
            Console.WriteLine(player.Lives);
        }
        

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}