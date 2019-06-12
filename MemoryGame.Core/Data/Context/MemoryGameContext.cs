using MemoryGame.Core.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryGame.Core.Data.Context
{
    public class MemoryGameContext : DbContext
    {
        public MemoryGameContext(DbContextOptions<MemoryGameContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }

    }
}