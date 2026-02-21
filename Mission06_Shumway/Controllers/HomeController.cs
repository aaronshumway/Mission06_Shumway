using Microsoft.AspNetCore.Mvc;

namespace Mission06_Shumway.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult AboutJoel() => View();
}