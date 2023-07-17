using DataBaseModels;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HostelController;

public partial class RegistratePage : Page
{
    private DataBaseContext _dbContext;
    private RegistratePageValidation _validaitor;

    public RegistratePage()
    {
        _dbContext = new DataBaseContext();
        _validaitor = new RegistratePageValidation();

        InitializeComponent();
        InitializeRoomsCmbBx();
        DataContext = _validaitor;
    }

    #region Events
    private void AddButt_Click(object sender, RoutedEventArgs e)
    {
        AddClient();
    }

    private void InitializeBedCmbBxOnChoosingRoom(object sender, EventArgs e)
    {
        BedCmbBx.ItemsSource = _dbContext.Beds.Select(c => c).Where(c => c.RoomId.ToString() == RoomCmbBx.Text).ToList();
        BedCmbBx.DisplayMemberPath = "Id";
    }
    #endregion

    #region Logic
    private void InitializeRoomsCmbBx()
    {
        RoomCmbBx.ItemsSource = _dbContext.Rooms.ToList();
        RoomCmbBx.DisplayMemberPath = "Id";
    }

    private void AddClient()
    {
        if (App.GetValidationErrors(this).Length > 0)
            App.ShowMessageBox("", "Проверьте введенные данные!");
        else
        {
            DataBaseController.AddClient(NameTxtBx.Text, SurnameTxtBx.Text, Convert.ToInt32(BedCmbBx.Text),
                new DateTime(DateOfEnty.SelectedDate.Value.Ticks + TimeOfEntry.SelectedDateTime.Value.Ticks),
                new DateTime(DateOfEnty.SelectedDate.Value.Ticks + TimeOfEntry.SelectedDateTime.Value.Ticks).AddDays((double) ValueOfDays.Value));
        }
    }
    #endregion
}