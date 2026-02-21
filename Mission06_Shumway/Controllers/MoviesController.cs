using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Shumway.Models.Generated;

namespace Mission06_Shumway.Controllers;

// Controller responsible for handling all CRUD operations for Movies
public class MoviesController : Controller
{
    // Database context for interacting with SQLite database
    private readonly HiltonMovieContext _context;
    
    // Constructor with dependency injection of the DbContext
    public MoviesController(HiltonMovieContext context)
    {
        _context = context;
    }
    
    // Displays list of movies sorted alphabetically by Title
    public async Task<IActionResult> Index()
    {
        var movies = await _context.Movies
            .OrderBy(m => m.Title)
            .ToListAsync();
        return View(movies);
    }
    
    // GET: Movies/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Movie { Edited = 0, CopiedToPlex = 0 });
    }

// POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Movie movie)
    {
        if (movie.Year < 1888)
        {
            ModelState.AddModelError(nameof(Movie.Year), "Year must be 1888 or later.");
        }

        if (!ModelState.IsValid)
            return View(movie);

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    
    // GET: Movies/Edit
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();

        return View(movie);
    }

// POST: Movies/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Movie movie)
    {
        if (id != movie.MovieId) return BadRequest();

        // enforce year rule
        if (movie.Year < 1888)
            ModelState.AddModelError(nameof(Movie.Year), "Year must be 1888 or later.");

        if (!ModelState.IsValid)
            return View(movie);

        _context.Update(movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    
    // GET: Movies/Delete
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
        if (movie == null) return NotFound();

        return View(movie);
    }

// POST: Movies/Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    
    
}