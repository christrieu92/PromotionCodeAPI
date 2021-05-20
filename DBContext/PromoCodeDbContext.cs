using Microsoft.EntityFrameworkCore;
using PromotionCodeAPI.Domain;

namespace PromotionCodeAPI.DBContext
{
    public class PromoCodeDbContext : DbContext
    {
        public PromoCodeDbContext(DbContextOptions<PromoCodeDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }

        public DbSet<Bonus> Bonus { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
