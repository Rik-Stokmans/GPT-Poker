using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GPT_Poker.Controllers;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (HttpContext.Session.TryGetValue("user", out _))
        {
            if (context.Controller.GetType() == typeof(LoginController))
            {
                context.Result = RedirectToAction("Index", "Home");
            }
        }
        else if (context.Controller.GetType() != typeof(LoginController))
        {
            context.Result = RedirectToAction("Index", "Login");
        }
        
        base.OnActionExecuting(context);
    }
    
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Login");
    }
}