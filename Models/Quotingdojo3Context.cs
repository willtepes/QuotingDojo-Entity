using Microsoft.EntityFrameworkCore;


namespace quotingdojo3.Models
{
    public class Quotingdojo3Context : DbContext
    {
        public Quotingdojo3Context(DbContextOptions<Quotingdojo3Context> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}