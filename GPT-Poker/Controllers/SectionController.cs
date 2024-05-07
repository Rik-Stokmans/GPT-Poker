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
        
        
        var sectionProgress = Core.GetAllAccountSectionProgresses(account)?.Find(x => x.SectionId == sectionId);
        
        var sections = Core.GetAllSections();
        sections ??= [];
        
        

        var unitProgress = Core.GetAllAccountUnitProgresses(account);
        unitProgress ??= [];
        
        var units = Core.GetAllUnits();
        units ??= [];
        
        

        var lessonProgress = Core.GetAllAccountLessonProgresses(account);
        lessonProgress ??= [];
        
        var lessons = Core.GetAllLessons();
        lessons ??= [];
        
        

        var accountProgressModel = new AccountProgressModel(account, sectionProgress, unitProgress, lessonProgress, sections, units, lessons);
        
        return View(accountProgressModel);
        
    }
}