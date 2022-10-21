using Microsoft.EntityFrameworkCore;
using PlakDukkani_MaratonEFCore.DAL.Config;
using PlakDukkani_MaratonEFCore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani_MaratonEFCore.DAL.Context
{
    public class PlakDbContext:DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MAKL7QI; Database=PlakStoreDB; Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfig());
            modelBuilder.ApplyConfiguration(new AlbumConfig());
            modelBuilder.ApplyConfiguration(new AdminConfig());

            modelBuilder.Entity <Admin >().HasIndex(t => t.AdminName).IsUnique();
        }

    }
}
