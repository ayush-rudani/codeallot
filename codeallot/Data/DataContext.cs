using codeallot.Models;
using Microsoft.EntityFrameworkCore;

namespace codeallot.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Codex> Codexes { get; set; }
    }
}
