using System;
using System.Collections.Generic;

namespace HostelController.DataBaseModels;

public class CurrentClient
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required DateTime CheckInDate { get; set; }
    public required DateTime CheckOutDate { get; set; }
    public required int BedId { get; set; }
    public Bed Bed { get; set; } = null!;
}

public class Room
{
    public int Id { get; set; }
    public ICollection<Bed> Beds { get; } = new List<Bed>();
}

public class Bed
{
    public int Id { get; set; }
    public required int Number { get; set; }
    public required bool IsOccupied { get; set; }
    public required int RoomId { get; set; }
    public Room Room { get; set; } = null!;
    public int? CurrentClientId { get; set; }
    public CurrentClient? CurrentClient { get; set; }
    public ICollection<ClientBooking>? ClientBooking { get; }
    public ICollection<ClientsHistory>? ClientsHistories { get; }
}

public class ClientsHistory
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required DateTime DateOfEntry { get; set; }
    public required DateTime DateOfLeave { get; set; }
    public required int BedId { get; set; }
    public Bed Bed { get; set; } = null!;
}

public class ClientBooking
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required DateTime CheckInDate { get; set; }
    public required DateTime CheckOutDate { get; set; }
    public required int BedId { get; set; }
    public Bed Bed { get; set; } = null!;
}