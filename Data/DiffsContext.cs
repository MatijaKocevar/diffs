using Diffing.Models;
using Microsoft.EntityFrameworkCore;

namespace Diffing.Data
{
    //inherits from DBContext class
    public class DiffingContext : DbContext
    {
        //constructor...pass in options of our context
        public DiffingContext(DbContextOptions<DiffingContext> opt) : base(opt) { }

        //representation of our Pair objects which get passed down to our database
        public DbSet<Pair> Pairs { get; set; }
    }
}