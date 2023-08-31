using Microsoft.EntityFrameworkCore;

namespace HostelController.DataBaseModels;

internal class DataBaseContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Bed> Beds { get; set; }
    public DbSet<ClientsHistory> ClientsHistory { get; set; }

    public DataBaseContext() => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Bed bed1 = new() { Id = 1, Number = 1, RoomId = 1 };
        Bed bed2 = new() { Id = 2, Number = 2, RoomId = 1 };
        Bed bed3 = new() { Id = 3, Number = 3, RoomId = 1 };
        Bed bed4 = new() { Id = 4, Number = 4, RoomId = 1 };

        Bed bed5 = new() { Id = 5, Number = 1, RoomId = 2 };
        Bed bed6 = new() { Id = 6, Number = 2, RoomId = 2 };
        Bed bed7 = new() { Id = 7, Number = 3, RoomId = 2 };
        Bed bed8 = new() { Id = 8, Number = 4, RoomId = 2 };

        Bed bed9 = new() { Id = 9, Number = 1, RoomId = 3 };
        Bed bed10 = new() { Id = 10, Number = 2, RoomId = 3 };
        Bed bed11 = new() { Id = 11, Number = 3, RoomId = 3 };
        Bed bed12 = new() { Id = 12, Number = 4, RoomId = 3 };

        Bed bed13 = new() { Id = 13, Number = 1, RoomId = 4 };
        Bed bed14 = new() { Id = 14, Number = 2, RoomId = 4 };
        Bed bed15 = new() { Id = 15, Number = 3, RoomId = 4 };
        Bed bed16 = new() { Id = 16, Number = 4, RoomId = 4 };

        Bed bed17 = new() { Id = 17, Number = 1, RoomId = 5 };
        Bed bed18 = new() { Id = 18, Number = 2, RoomId = 5 };
        Bed bed19 = new() { Id = 19, Number = 3, RoomId = 5 };
        Bed bed20 = new() { Id = 20, Number = 4, RoomId = 5 };

        Bed bed21 = new() { Id = 21, Number = 1, RoomId = 6 };
        Bed bed22 = new() { Id = 22, Number = 2, RoomId = 6 };
        Bed bed23 = new() { Id = 23, Number = 3, RoomId = 6 };
        Bed bed24 = new() { Id = 24, Number = 4, RoomId = 6 };

        Bed bed25 = new() { Id = 25, Number = 1, RoomId = 7 };
        Bed bed26 = new() { Id = 26, Number = 2, RoomId = 7 };
        Bed bed27 = new() { Id = 27, Number = 3, RoomId = 7 };
        Bed bed28 = new() { Id = 28, Number = 4, RoomId = 7 };

        Bed bed29 = new() { Id = 29, Number = 1, RoomId = 8 };
        Bed bed30 = new() { Id = 30, Number = 2, RoomId = 8 };
        Bed bed31 = new() { Id = 31, Number = 3, RoomId = 8 };
        Bed bed32 = new() { Id = 32, Number = 4, RoomId = 8 };

        modelBuilder.Entity<Bed>().HasData(
            bed1, bed2, bed3, bed4, bed5, bed6, bed7, bed8, bed9, bed10,
            bed11, bed12, bed13, bed14, bed15, bed16, bed17, bed18, bed19,
            bed20, bed21, bed22, bed23, bed24, bed25, bed26, bed27, bed28, bed29,
            bed30, bed31, bed32);

        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1 },
            new Room { Id = 2 },
            new Room { Id = 3 },
            new Room { Id = 4 },
            new Room { Id = 5 },
            new Room { Id = 6 },
            new Room { Id = 7 },
            new Room { Id = 8 });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HostelController;Trusted_Connection=True;");
}