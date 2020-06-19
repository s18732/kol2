using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class EventDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artist_Event> Artist_Events { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Event_Organiser> Event_Organisers { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public EventDbContext()
        {

        }
        public EventDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>((builder) =>
            {
                builder.HasKey(e => e.IdArtist);
                builder.Property(e => e.IdArtist).ValueGeneratedOnAdd();

                builder.Property(e => e.Nickname).HasMaxLength(30);
                builder.Property(e => e.Nickname).IsRequired();

                builder.HasMany(e => e.Artist_Events).WithOne(e => e.Artist).HasForeignKey(e => e.IdArtist).IsRequired();
            });
            modelBuilder.Entity<Artist_Event>((builder) =>
            {
                builder.HasKey(e => new
                {
                    e.IdArtist,
                    e.IdEvent
                });

                builder.Property(e => e.PerformanceDate).IsRequired();
            });
            modelBuilder.Entity<Event>((builder) =>
            {
                builder.HasKey(e => e.IdEvent);
                builder.Property(e => e.IdEvent).ValueGeneratedOnAdd();

                builder.Property(e => e.Name).HasMaxLength(100);
                builder.Property(e => e.Name).IsRequired();

                builder.Property(e => e.StartDate).IsRequired();

                builder.Property(e => e.EndDate).IsRequired();

                builder.HasMany(e => e.Artist_Events).WithOne(e => e.Event).HasForeignKey(e => e.IdEvent).IsRequired();

                builder.HasMany(e => e.Event_Organisers).WithOne(e => e.Event).HasForeignKey(e => e.IdEvent).IsRequired();
            });
            modelBuilder.Entity<Event_Organiser>((builder) =>
            {
                builder.HasKey(e => new
                {
                    e.IdEvent,
                    e.IdOrganiser
                });
            });
            modelBuilder.Entity<Organiser>((builder) =>
            {
                builder.HasKey(e => e.IdOrganiser);
                builder.Property(e => e.IdOrganiser).ValueGeneratedOnAdd();

                builder.Property(e => e.Name).HasMaxLength(30);
                builder.Property(e => e.Name).IsRequired();

                builder.HasMany(e => e.Event_Organisers).WithOne(e => e.Organiser).HasForeignKey(e => e.IdOrganiser).IsRequired();
            });

        }
    }
}
