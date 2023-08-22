using System;
using System.Collections.Generic;
using System.Linq;

namespace HostelController.DataBaseModels;

internal class DataBaseController
{
    private static readonly DataBaseContext _dbContext = new();

    public static void AddClient(string name, string surname, int bedId, DateTime checkInDate, DateTime checkOutDate)
    {
        try
        {
            Client newCLient = new()
            {
                Name = name,
                Surname = surname,
                BedId = bedId,
                ClientBed = _dbContext.Beds.First(c => c.Id == bedId),
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
            };

            _dbContext.Clients.Add(newCLient);
            _dbContext.SaveChanges();
            App.ShowMessageBox("", "Гость добавлен!");

            UpdateBedStatus(bedId, true);
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
        }
    }

    public static void UpdateBedStatus(int bedId, bool isOccupied)
    {
        try
        {
            Bed bed = _dbContext.Beds.First(c => c.Id == bedId);
            bed.IsOccupied = isOccupied;
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("", ex.Message);
        }

        _dbContext.SaveChanges();
    }

    public static Client GetClientByBedId(int bedId)
    {
        try
        {
            return _dbContext.Clients.Where(c => c.BedId == bedId).FirstOrDefault();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("", ex.Message);
            return null;
        }
    }

    public static List<Bed> GetBedsListByRoomId(int roomId)
    {
        try
        {
            return _dbContext.Beds.Where(c => c.RoomId == roomId).ToList();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("", ex.Message);
            return null;
        }
    }

    public static Bed GetBedById(int bedId)
    {
        try
        {
            return _dbContext.Beds.Find(bedId);
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("", ex.Message);
            return null;
        }
    }

    public static Room GetRoomById(int roomId)
    {
        try
        {
            return _dbContext.Rooms.First(c => c.Id == roomId);
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("", ex.Message);
            return null;
        }
    }

    public static void RemoveClientById(int clientId)
    {
        try
        {
            Client removedClient = _dbContext.Clients.FirstOrDefault(c => c.Id == clientId);

            UpdateBedStatus(removedClient.BedId, false);
            _dbContext.Clients.Remove(removedClient);

            App.ShowMessageBox("", "Гость выселен!");
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("", ex.Message);
        }
    }

}