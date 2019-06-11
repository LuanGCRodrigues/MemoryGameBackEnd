using MemoryGame.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Core.Data.Context
{
  public class MemoryGameContext : DbContext
  {
    public MemoryGameContext(DbContextOptions<MemoryGameContext> options) : base(options)
    { }

    DbSet<User> Users { get; set; }
    DbSet<Score> Scores { get; set; }

  }
}