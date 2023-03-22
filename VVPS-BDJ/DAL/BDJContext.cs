using Microsoft.EntityFrameworkCore;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.DAL
{
    public class BDJContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<TimetableRecord> TimetableRecords { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }
        public DbSet<ElderlyDiscountCard> ElderlyDiscountCards { get; set; }
        public DbSet<FamilyDiscountCard> FamilyDiscountCards { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bdj-sqlite.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            User defaultAdminUser =
                new(1, "Admin", "Admin", "admin", "admin", DateTime.MinValue, true);
            modelBuilder.Entity<User>().HasData(defaultAdminUser);
            modelBuilder
                .Entity<User>()
                .HasOne(user => user.DiscountCard)
                .WithOne()
                .HasForeignKey<User>(user => user.DiscountCardId);
        }
    }
}
