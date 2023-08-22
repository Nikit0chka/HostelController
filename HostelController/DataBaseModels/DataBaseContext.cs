using Microsoft.EntityFrameworkCore;

namespace HostelController.DataBaseModels;

internal class DataBaseContext : DbContext
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
        Bed bed1 = new Bed { Id = 1, Number = 1, RoomId = 1 };
        Bed bed2 = new Bed { Id = 2, Number = 2, RoomId = 1 };
        Bed bed3 = new Bed { Id = 3, Number = 3, RoomId = 1 };
        Bed bed4 = new Bed { Id = 4, Number = 4, RoomId = 1 };

        Bed bed5 = new Bed { Id = 5, Number = 1, RoomId = 2 };
        Bed bed6 = new Bed { Id = 6, Number = 2, RoomId = 2 };
        Bed bed7 = new Bed { Id = 7, Number = 3, RoomId = 2 };
        Bed bed8 = new Bed { Id = 8, Number = 4, RoomId = 2 };

        Bed bed9 = new Bed { Id = 9, Number = 1, RoomId = 3 };
        Bed bed10 = new Bed { Id = 10, Number = 2, RoomId = 3 };
        Bed bed11 = new Bed { Id = 11, Number = 3, RoomId = 3 };
        Bed bed12 = new Bed { Id = 12, Number = 4, RoomId = 3 };

        Bed bed13 = new Bed { Id = 13, Number = 1, RoomId = 4 };
        Bed bed14 = new Bed { Id = 14, Number = 2, RoomId = 4 };
        Bed bed15 = new Bed { Id = 15, Number = 3, RoomId = 4 };
        Bed bed16 = new Bed { Id = 16, Number = 4, RoomId = 4 };

        Bed bed17 = new Bed { Id = 17, Number = 1, RoomId = 5 };
        Bed bed18 = new Bed { Id = 18, Number = 2, RoomId = 5 };
        Bed bed19 = new Bed { Id = 19, Number = 3, RoomId = 5 };
        Bed bed20 = new Bed { Id = 20, Number = 4, RoomId = 5 };

        Bed bed21 = new Bed { Id = 21, Number = 1, RoomId = 6 };
        Bed bed22 = new Bed { Id = 22, Number = 2, RoomId = 6 };
        Bed bed23 = new Bed { Id = 23, Number = 3, RoomId = 6 };
        Bed bed24 = new Bed { Id = 24, Number = 4, RoomId = 6 };

        Bed bed25 = new Bed { Id = 25, Number = 1, RoomId = 7 };
        Bed bed26 = new Bed { Id = 26, Number = 2, RoomId = 7 };
        Bed bed27 = new Bed { Id = 27, Number = 3, RoomId = 7 };
        Bed bed28 = new Bed { Id = 28, Number = 4, RoomId = 7 };

        Bed bed29 = new Bed { Id = 29, Number = 1, RoomId = 8 };
        Bed bed30 = new Bed { Id = 30, Number = 2, RoomId = 8 };
        Bed bed31 = new Bed { Id = 31, Number = 3, RoomId = 8 };
        Bed bed32 = new Bed { Id = 32, Number = 4, RoomId = 8 };

        Bed bed33 = new Bed { Id = 33, Number = 1, RoomId = 9 };
        Bed bed34 = new Bed { Id = 34, Number = 2, RoomId = 9 };
        Bed bed35 = new Bed { Id = 35, Number = 3, RoomId = 9 };
        Bed bed36 = new Bed { Id = 36, Number = 4, RoomId = 9 };

        Bed bed37 = new Bed { Id = 37, Number = 1, RoomId = 10 };
        Bed bed38 = new Bed { Id = 38, Number = 2, RoomId = 10 };
        Bed bed39 = new Bed { Id = 39, Number = 3, RoomId = 10 };
        Bed bed40 = new Bed { Id = 40, Number = 4, RoomId = 10 };
        /*
                List<Bed> beds1 = new List<Bed> { bed1, bed2, bed3, bed4 };
                List<Bed> beds2 = new List<Bed> { bed5, bed6, bed7, bed8 };
                List<Bed> beds3 = new List<Bed> { bed9, bed10, bed11, bed12 };
                List<Bed> beds4 = new List<Bed> { bed13, bed14, bed15, bed16 };
                List<Bed> beds5 = new List<Bed> { bed17, bed18, bed19, bed20 };
                List<Bed> beds6 = new List<Bed> { bed21, bed22, bed23, bed24 };
                List<Bed> beds7 = new List<Bed> { bed25, bed26, bed27, bed28 };
                List<Bed> beds8 = new List<Bed> { bed29, bed30, bed31, bed32 };
                List<Bed> beds9 = new List<Bed> { bed33, bed34, bed35, bed36 };
                List<Bed> beds10 = new List<Bed> { bed37, bed38, bed39, bed40 };
        */
        modelBuilder.Entity<Bed>().HasData(
            bed1, bed2, bed3, bed4, bed5, bed6, bed7, bed8, bed9, bed10,
            bed11, bed12, bed13, bed14, bed15, bed16, bed17, bed18, bed19,
            bed20, bed21, bed22, bed23, bed24, bed25, bed26, bed27, bed28, bed29,
            bed30, bed31, bed32, bed33, bed34, bed35, bed36, bed37, bed38, bed39, bed40);

        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1 },
            new Room { Id = 2 },
            new Room { Id = 3 },
            new Room { Id = 4 },
            new Room { Id = 5 },
            new Room { Id = 6 },
            new Room { Id = 7 },
            new Room { Id = 8 },
            new Room { Id = 9 },
            new Room { Id = 10 });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HostelController;Trusted_Connection=True;");
    }
}