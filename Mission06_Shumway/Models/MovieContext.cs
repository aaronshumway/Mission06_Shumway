using Microsoft.EntityFrameworkCore;

namespace Mission06_Shumway.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base (options) //Constructor
    {
    }
    
    public DbSet<Submission> Movies { get; set; }
}