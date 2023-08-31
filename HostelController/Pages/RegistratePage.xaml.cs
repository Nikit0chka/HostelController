using HostelController.DataBaseModels;
using HostelController.PageValidation;

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HostelController.Pages;

public partial class RegistratePage : Page
{
    private readonly Room _chosedRoom;
    private readonly Bed _chosedBed;

    public RegistratePage(int bedId)
    {
        _chosedBed = DataBaseController.GetBedById(bedId);
        _chosedRoom = DataBaseController.GetRoomById(_chosedBed.RoomId);

        DataContext = new RegistratePageValidation();

        Initialized += RegistratePage_Initialized;
        InitializeComponent();
    }

    public RegistratePage()
    {
        DataContext = new RegistratePageValidation();

        InitializeComponent();
        ClearControls();
    }

    #region Events
    private void RegistratePage_Initialized(object? sender, EventArgs e) => SetControlsByRoomBedData();

    private void AddButt_Click(object sender, RoutedEventArgs e) => AddClient();

    private void RoomCmbBx_LostFocus(object sender, RoutedEventArgs e) => InitializeBedCmbBx();
    #endregion

    #region Logic
    private void InitializeBedCmbBx()
    {
        BedCmbBx.ItemsSource = DataBaseController.GetBedsListByRoomId(Convert.ToInt32(RoomCmbBx.Text)).Where(c => !c.IsOccupied).ToList();
        BedCmbBx.DisplayMemberPath = "Number";
    }

    private void InitializeRoomsCmbBx()
    {
        RoomCmbBx.ItemsSource = DataBaseController.GetRoomsList();
        RoomCmbBx.DisplayMemberPath = "Id";
    }

    private void AddClient()
    {
        if (App.GetValidationErrors(this).Length > 0)
        {
            App.ShowMessageBox("", "Проверьте введенные данные!");
        }
        else
        {
            DataBaseController.AddClient(NameTxtBx.Text, SurnameTxtBx.Text, ((Bed) BedCmbBx.SelectedItem).Id,
                DateTime.Now, DateTime.Now.AddDays((double) ValueOfDays.Value));

            App.ShowMessageBox("", "Гость добавлен!");

            ClearControls();
        }
    }

    private void ClearControls()
    {
        NameTxtBx.Text = null;
        SurnameTxtBx.Text = null;

        InitializeRoomsCmbBx();
        RoomCmbBx.Text = null;
        InitializeBedCmbBx();
        BedCmbBx.Text = null;

        ValueOfDays.Value = null;
    }

    private void SetControlsByRoomBedData()
    {
        NameTxtBx.Text = null;
        SurnameTxtBx.Text = null;

        InitializeRoomsCmbBx();
        RoomCmbBx.Text = _chosedRoom.Id.ToString();
        InitializeBedCmbBx();
        BedCmbBx.Text = _chosedBed.Number.ToString();

        ValueOfDays.Value = null;
    }
    #endregion
}