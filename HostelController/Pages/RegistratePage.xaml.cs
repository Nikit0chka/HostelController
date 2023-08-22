using HostelController.DataBaseModels;
using HostelController.PageValidation;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HostelController;

public partial class RegistratePage : Page
{
    private readonly Room _chosedRoom;
    private readonly Bed _chosedBed;
    private readonly DataBaseContext _dbContext;

    public RegistratePage(int bedId)
    {
        _dbContext = new DataBaseContext();
        _chosedBed = DataBaseController.GetBedById(bedId);
        _chosedRoom = DataBaseController.GetRoomById(_chosedBed.RoomId);

        DataContext = new RegistratePageValidation();

        Initialized += RegistratePage_Initialized;
        InitializeComponent();
    }

    #region Events
    private void RegistratePage_Initialized(object? sender, EventArgs e)
    {
        ClearControls();
    }

    private void AddButt_Click(object sender, RoutedEventArgs e)
    {
        AddClient();
    }

    private void RoomCmbBx_LostFocus(object sender, RoutedEventArgs e)
    {
        InitializeBedCmbBxOnChoosingRoom();
    }
    #endregion

    #region Logic
    private void InitializeBedCmbBxOnChoosingRoom()
    {
        BedCmbBx.ItemsSource = DataBaseController.GetBedsListByRoomId(RoomCmbBx\
            );
            _dbContext.Beds.Select(c => c).Where(c => c.RoomId.ToString() == RoomCmbBx.Text && !c.IsOccupied).ToList();
        BedCmbBx.DisplayMemberPath = "Number";
    }

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
            DataBaseController.AddClient(NameTxtBx.Text, SurnameTxtBx.Text, (BedCmbBx.SelectedItem as Bed).Id,
                new DateTime(DateOfEnty.SelectedDate.Value.Ticks + TimeOfEntry.SelectedDateTime.Value.TimeOfDay.Ticks),
                new DateTime(DateOfEnty.SelectedDate.Value.Ticks + TimeOfEntry.SelectedDateTime.Value.TimeOfDay.Ticks).AddHours((double) ValueOfDays.Value * 12));

            ClearControls();
        }

        NavigationService.Navigate(new BedAdministrationPage(_chosedBed.Id));
    }

    private void ClearControls()
    {
        NameTxtBx.Text = null;
        SurnameTxtBx.Text = null;

        InitializeRoomsCmbBx();
        RoomCmbBx.SelectedItem = _chosedRoom;
        InitializeBedCmbBxOnChoosingRoom();
        BedCmbBx.SelectedItem = _chosedBed;

        DateOfEnty.SelectedDate = DateTime.Now;
        TimeOfEntry.SelectedDateTime = DateTime.Now;
        ValueOfDays.Value = null;
    }
    #endregion
}