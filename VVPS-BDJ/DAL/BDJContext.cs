using Microsoft.EntityFrameworkCore;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.DAL
{
    public class BDJContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<TimetableRecord> TimetableRecord { get; set; }
        public DbSet<DiscountCard> DiscountCards { get; set; }
        public DbSet<ElderlyDiscountCard> ElderlyDiscountCards { get; set; }
        public DbSet<FamilyDiscountCard> FamilyDiscountCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bdj-sqlite.db");
        }

    }
}
