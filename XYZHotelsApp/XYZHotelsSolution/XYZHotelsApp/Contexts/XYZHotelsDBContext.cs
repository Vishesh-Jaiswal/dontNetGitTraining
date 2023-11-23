using Microsoft.EntityFrameworkCore;
using XYZHotelsApp.Models;

namespace XYZHotelsApp.Contexts
{
    public class XYZHotelsDBContext : DbContext
    {
        public XYZHotelsDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hotel>()
                .Property(h => h.PricePerNight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Reservations)
                .WithOne(res => res.Room)
                .HasForeignKey(res => res.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Users)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.Username)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
