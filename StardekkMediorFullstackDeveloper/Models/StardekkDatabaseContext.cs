using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StardekkMediorFullstackDeveloper.Models
{
    public class StardekkDatabaseContext : DbContext
    {
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amanities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=StardekkMediorFullstackDeveloper.db");
    }
}
