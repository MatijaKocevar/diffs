using base64diffs.Models;
using Microsoft.EntityFrameworkCore;

namespace base64diffs.Data
{
    public class base64diffsContext : DbContext
    {
        public base64diffsContext(DbContextOptions<base64diffsContext> opt) : base(opt) { }
        public DbSet<Pair> Pairs { get; set; }
    }
}