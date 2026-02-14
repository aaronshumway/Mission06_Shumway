using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Shumway.Models;

namespace Mission06_Shumway.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    
    public HomeController(MovieContext temp) // Constructor
    {
        _context = temp;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult AboutJoel()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddMovie(Submission response)
    {
        _context.Movies.Add(response); // Add record to the database
        _context.SaveChanges(); // Save
        
        return View("Confirmation", response);
    }

}