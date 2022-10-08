using Microsoft.EntityFrameworkCore;
using TrueRealtor.Data.Constants;
using TrueRealtor.Data.Entities;

namespace TrueRealtor.Data
{
    public class TrueRealtorContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }

        public TrueRealtorContext(DbContextOptions<TrueRealtorContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable(nameof(Apartment));

                entity.HasKey(a => a.Id);

                entity.Property(a => a.Address).HasMaxLength(DbConstant.AddressMaxLenght);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(nameof(User));

                entity.HasKey(u => u.Id);
            });

        }
    }
}
