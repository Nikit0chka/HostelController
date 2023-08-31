using System;
using System.Collections.Generic;
using System.Linq;

namespace HostelController.DataBaseModels;

internal class DataBaseController
{
    private static readonly DataBaseContext _dbContext = new();

    #region Client
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

            UpdateBedStatus(bedId, true);
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
        }
    }

    public static void UpdateClientStay(int clientId, DateTime newCheckOutDate)
    {
        try
        {
            _dbContext.Clients.FirstOrDefault(c => c.Id == clientId).CheckOutDate = newCheckOutDate;
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exeption!", ex.Message);
        }
    }

    public static List<Client> GetClientsList()
    {
        try
        {
            return _dbContext.Clients.ToList();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
            return null;
        }
    }

    public static Client GetClientByBedId(int bedId)
    {
        try
        {
            return _dbContext.Clients.Where(c => c.BedId == bedId).FirstOrDefault();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
            return null;
        }
    }

    public static Client GetCLientById(int clientId)
    {
        try
        {
            return _dbContext.Clients.Where(c => c.Id == clientId).FirstOrDefault();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
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
            AddClientToHistory(removedClient);

            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
        }
    }
    #endregion
    #region Bed
    public static void UpdateBedStatus(int bedId, bool isOccupied)
    {
        try
        {
            Bed bed = _dbContext.Beds.First(c => c.Id == bedId);
            bed.IsOccupied = isOccupied;
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
        }

        _dbContext.SaveChanges();
    }

    public static List<Bed> GetBedsListByRoomId(int roomId)
    {
        try
        {
            return _dbContext.Beds.Where(c => c.RoomId == roomId).ToList();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
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
            App.ShowMessageBox("Exception!", ex.Message);
            return null;
        }
    }
    #endregion
    #region Room
    public static Room GetRoomById(int roomId)
    {
        try
        {
            return _dbContext.Rooms.First(c => c.Id == roomId);
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
            return null;
        }
    }

    public static int GetRoomFreeBedsCount(int roomId)
    {
        try
        {
            return _dbContext.Beds.Where(c => c.RoomId == roomId && !c.IsOccupied).Count();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
            return 0;
        }
    }

    public static List<Room> GetRoomsList()
    {
        try
        {
            return _dbContext.Rooms.ToList();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
            return null;
        }
    }
    #endregion
    #region History
    private static void AddClientToHistory(Client client)
    {
        try
        {
            _dbContext.ClientsHistory.Add(new ClientsHistory { BedId = client.BedId, Name = client.Name, Surname = client.Surname, DateOfEntry = client.CheckInDate, DateOfLeave = DateTime.Now });
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
        }
    }

    public static List<ClientsHistory> GetClientsHistories()
    {
        try
        {
            return _dbContext.ClientsHistory.ToList();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
            return null;
        }
    }

    public static void DeleteClientHistory(ClientsHistory clientHistory)
    {
        try
        {
            _dbContext.ClientsHistory.Remove(clientHistory);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            App.ShowMessageBox("Exception!", ex.Message);
        }
    }
    #endregion
}