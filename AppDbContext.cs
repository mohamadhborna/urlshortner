using Microsoft.EntityFrameworkCore;
using  urlShortner.models;
namespace urlShortner
{
    public class AppDbContext:DbContext
    {
        public DbSet<Url> urls{get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Url>().ToTable("urls");
            builder.Entity<Url>().HasKey(p => p.ShortUrl);
            builder.Entity<Url>().Property(p => p.LongUrl).IsRequired();
            builder.Entity<Url>().Property(p => p.ShortUrl).IsRequired();
            
        }
        
    }
}