using HostelController.DataBaseModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HostelController;

public partial class RoomInfoPage : Page
{
    private readonly List<Bed> _beds;
    private readonly List<Button> _bedButtons;

    public RoomInfoPage(int roomId)
    {
        _bedButtons = new List<Button>();
        _beds = DataBaseController.GetBedsListByRoomId(roomId);

        InitializeComponent();
        InitializeBeds();
        CheckBedStatus();
    }

    #region Events
    private void OpenRegistrationPageOnClick(object sender, RoutedEventArgs e)
    {
        int bedId = Convert.ToInt32((sender as Button).Tag);

        NavigationService.Navigate(new RegistratePage(bedId));
    }

    private void OpenBedAdministrationPage(object sender, RoutedEventArgs e)
    {
        int bedId = _beds.Where(c => c.Id == Convert.ToInt32((sender as Button).Tag)).First().Id;

        NavigationService.Navigate(new BedAdministrationPage(bedId));
    }
    #endregion

    #region Logic
    private void InitializeBeds()
    {
        foreach (Bed bed in _beds)
        {
            Button bedButton = new()
            {
                Name = "Bed" + bed.Number.ToString(),
                Content = "Кровать " + bed.Number.ToString(),
                Style = (Style) Application.Current.Resources["MahApps.Styles.Button.Square"],
                Height = 80,
                Width = 150,
                FontSize = 16,
                BorderThickness = new Thickness(3),
                Tag = bed.Id
            };
            bedButton.Click += new RoutedEventHandler(OpenBedAdministrationPage);

            BedsButtUnGrid.Children.Add(bedButton);
            _bedButtons.Add(bedButton);
        }
    }

    private void CheckBedStatus()
    {
        foreach (Bed bed in _beds)
        {
            Client client = DataBaseController.GetClientByBedId(bed.Id);

            if (bed.IsOccupied)
            {
                if (client.CheckOutDate < DateTime.Now || client.CheckOutDate < DateTime.Now.Subtract(TimeSpan.FromHours(1)))
                    ColorBed(bed.Id, Brushes.Red);
                else if (client.CheckOutDate < DateTime.Now.Subtract(TimeSpan.FromHours(2)))
                    ColorBed(bed.Id, Brushes.Yellow);
                else
                    ColorBed(bed.Id, Brushes.Gray);
            }
            else
                ColorBed(bed.Id, Brushes.White);
        }
    }

    private void ColorBed(int bedId, Brush color)
    {
        _bedButtons.First(c => Convert.ToInt32(c.Tag) == bedId).Background = color;
    }
    #endregion
}