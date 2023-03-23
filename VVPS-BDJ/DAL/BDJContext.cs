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

            // Seeded data
            User defaultAdminUser =
                new(1, "Admin", "Admin", "admin", "admin", DateTime.MinValue, true);
            modelBuilder.Entity<User>().HasData(defaultAdminUser);

            modelBuilder
                .Entity<TimetableRecord>()
                .HasData(
                    new TimetableRecord(
                        1,
                        "Sofia",
                        "Plovdiv",
                        new TimeOnly(8, 0),
                        new TimeOnly(10, 0),
                        10.0
                    ),
                    new TimetableRecord(
                        2,
                        "Sofia",
                        "Varna",
                        new TimeOnly(10, 0),
                        new TimeOnly(12, 0),
                        15.35
                    ),
                    new TimetableRecord(
                        3,
                        "Sofia",
                        "Burgas",
                        new TimeOnly(12, 0),
                        new TimeOnly(14, 0),
                        11.80
                    ),
                    new TimetableRecord(
                        4,
                        "Sofia",
                        "Plovdiv",
                        new TimeOnly(14, 0),
                        new TimeOnly(16, 0),
                        9.90
                    ),
                    new TimetableRecord(
                        5,
                        "Varna",
                        "Sofia",
                        new TimeOnly(16, 0),
                        new TimeOnly(18, 0),
                        15.35
                    ),
                    new TimetableRecord(
                        6,
                        "Varna",
                        "Burgas",
                        new TimeOnly(18, 0),
                        new TimeOnly(20, 0),
                        14.50
                    )
                );

            modelBuilder
                .Entity<User>()
                .HasOne(user => user.DiscountCard)
                .WithOne()
                .HasForeignKey<User>(user => user.DiscountCardId);
        }
    }
}
