using HostelController.DataBaseModels;
using HostelController.PageValidation;

using System;
using System.Linq;
using System.Windows.Controls;

namespace HostelController.Pages;

public partial class BookingPage : Page
{
    public BookingPage()
    {
        DataContext = new BookingPageValidation();

        InitializeComponent();
        ClearControls();
    }

    #region Events
    private void RoomCmbBx_LostFocus(object sender, System.Windows.RoutedEventArgs e) => InitializeBedCmbBx();

    private void BookButt_Click(object sender, System.Windows.RoutedEventArgs e) => AddBooking();
    #endregion

    #region Logic
    private void InitializeBedCmbBx()
    {
        BedCmbBx.ItemsSource = DataBaseController.GetBedsListByRoomId(Convert.ToInt32(RoomCmbBx.Text))?.Where(c => !c.IsOccupied).ToList();
        BedCmbBx.DisplayMemberPath = "Number";
    }

    private void InitializeRoomsCmbBx()
    {
        RoomCmbBx.ItemsSource = DataBaseController.GetRoomsList();
        RoomCmbBx.DisplayMemberPath = "Id";
    }

    private void ClearControls()
    {
        NameTxtBx.Text = null;
        SurnameTxtBx.Text = null;

        InitializeRoomsCmbBx();
        RoomCmbBx.Text = null;
        InitializeBedCmbBx();
        BedCmbBx.Text = null;

        TimeOfEntry.SelectedDateTime = null;
        ValueOfDays.Value = null;
    }

    private void AddBooking()
    {
        if (App.GetValidationErrors(this).Length > 0)
        {
            App.ShowMessageBox("", "Проверьте введенные данные!");
        }
        else
        {
            DataBaseController.AddBooking(NameTxtBx.Text, SurnameTxtBx.Text,
                DateOfEntry.SelectedDate.Value + TimeOfEntry.SelectedDateTime.Value.TimeOfDay,
                (DateOfEntry.SelectedDate.Value + TimeOfEntry.SelectedDateTime.Value.TimeOfDay).AddDays(Convert.ToInt32(ValueOfDays.Value)),
                ((Bed) BedCmbBx.SelectedItem).Id);

            App.ShowMessageBox("", "Кровать забронирована!");

            ClearControls();
        }
    }
    #endregion
}
