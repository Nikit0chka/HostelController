using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataBaseModels;

class DataBaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Bed> Beds { get; set; }

    public DataBaseContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1 },
            new Room { Id = 2 },
            new Room { Id = 3 });

        modelBuilder.Entity<Bed>().HasData(
            new Bed { Id = 1, RoomId = 1, IsOccupied = false },
            new Bed { Id = 2, RoomId = 2, IsOccupied = true },
            new Bed { Id = 3, RoomId = 3, IsOccupied = false },
            new Bed { Id = 4, RoomId = 2, IsOccupied = true });

        modelBuilder.Entity<Client>().HasData(
            new Client { Id = 1, BedId = 2, CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now, Name = "Nikita", Surname = "Vorontsov" },
            new Client { Id = 2, BedId = 4, CheckInDate = DateTime.Now, CheckOutDate = DateTime.Now, Name = "Anna", Surname = "Vorontsova" });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HostelController;Trusted_Connection=True;");
    }
}