using GPT_Poker.Models;
using LogicLayer.Core;
using LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace GPT_Poker.Controllers;

public class SectionController : BaseController
{
    public IActionResult Index(int sectionId)
    {
        
        Console.WriteLine(sectionId);
        
        
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
        
        
        var section = Core.GetSection(new Section(id: sectionId));
        var progress = Core.GetSectionProgress(account, section);
        
        
        return View(new SectionViewModel(section, progress));
        
    }
}