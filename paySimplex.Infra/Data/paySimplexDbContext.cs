using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using paySimplex.Infra.Data.Mappings;
using paySimplex.Domain.Models;

namespace paySimplex.Infra.Data
{
    public class PaySimplexDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PaySimplexDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal DbSet<User> Users { get; set; }
        internal DbSet<Chore> Chores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("PAYSIMPLEX")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ChoreMap());
        }
    }
}