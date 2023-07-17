using HostelController;

using System;
using System.Linq;

namespace DataBaseModels;

internal static class DataBaseController
{
    private static DataBaseContext _dbContext = new DataBaseContext();

    public static void AddClient(string name, string surname, int bedId, DateTime checkInDate, DateTime checkOutDate)
    {
        if (_dbContext.Beds.Any(c => c.Id == bedId))
        {
            try
            {
                _dbContext.Clients.Add(new Client
                {
                    Name = name,
                    Surname = surname,
                    BedId = bedId,
                    ClientBed = _dbContext.Beds.Where(c => c.Id == bedId).First(),
                    CheckInDate = checkInDate,
                    CheckOutDate = checkOutDate,
                });
                _dbContext.SaveChangesAsync();  
                App.ShowMessageBox("", "Гость добавлен!");              
            }
            catch (Exception ex)
            {
                App.ShowMessageBox("Exception!", ex.ToString());
            }            
        }
        else
            App.ShowMessageBox("", "Кровать с таким номером не зарегестрирована!");
    }
}