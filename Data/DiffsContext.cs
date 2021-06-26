using base64diffs.Models;
using Microsoft.EntityFrameworkCore;

namespace base64diffs.Data
{
    //inherits from DBContext class
    public class base64diffsContext : DbContext
    {
        //constructor...pass in options of our context
        public base64diffsContext(DbContextOptions<base64diffsContext> opt) : base(opt) { }

        //representation of our Pair objects which get passed down to our database
        public DbSet<Pair> Pairs { get; set; }
    }
}