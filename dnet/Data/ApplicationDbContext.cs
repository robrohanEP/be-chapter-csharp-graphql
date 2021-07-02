using Microsoft.EntityFrameworkCore;
using dnet;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
  {
  }

  public DbSet<Author> Authors { get; set; }
}