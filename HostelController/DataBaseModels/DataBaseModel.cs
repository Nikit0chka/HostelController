using System;
using System.Collections.Generic;

namespace HostelController.DataBaseModels;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int BedId { get; set; }
    public Bed ClientBed { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}

public class Room
{
    public int Id { get; set; }
    public ICollection<Bed> Beds { get; set; }
}

public class Bed
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public bool IsOccupied { get; set; }
}

public class ClientsHistory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int BedId { get; set; }
    public Bed Bed { get; set; }
    public DateTime DateOfEntry { get; set; }
    public DateTime DateOfLeave { get; set; }
}