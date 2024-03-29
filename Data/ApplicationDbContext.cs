using Windows_Backend.Data.Configurations;
using Windows_Backend.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Windows_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private IConfiguration Configuration { get; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<UserBusiness> UserBusiness { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration["ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BusinessConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new PromotionConfiguration());
            builder.ApplyConfiguration(new UserBusinessConfiguration());
        }
    }
}