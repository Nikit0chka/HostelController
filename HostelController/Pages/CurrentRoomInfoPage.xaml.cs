using HostelController.DataBaseModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HostelController.Pages;

public partial class CurrentRoomInfoPage : Page
{
    private readonly List<Bed>? _beds;
    private readonly List<Button> _bedButtons;

    public CurrentRoomInfoPage(int roomId)
    {
        _bedButtons = new List<Button>();
        _beds = DataBaseController.GetBedsListByRoomId(roomId);

        Loaded += RoomInfoPage_Loaded;
        Initialized += RoomInfoPage_Initialized;

        InitializeComponent();
    }

    #region Events
    private void RoomInfoPage_Initialized(object? sender, EventArgs e)
    {
        InitializeBeds();
        CheckBedStatus();
    }

    private void RoomInfoPage_Loaded(object sender, RoutedEventArgs e) => CheckBedStatus();

    private void OpenBedAdministrationPage(object sender, RoutedEventArgs e)
    {
        if (_beds is not null)
        {
            int bedId = _beds.Where(c => c.Id == Convert.ToInt32(((Button) sender).Tag)).First().Id;

            NavigationService.Navigate(new BedAdministrationPage(bedId));
        }
    }
    #endregion
    #region Logic
    private void InitializeBeds()
    {
        if (_beds is not null)
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
    }

    private void CheckBedStatus()
    {
        if (_beds is not null)
        {
            foreach (Bed bed in _beds)
            {
                CurrentClient? client = DataBaseController.GetClientByBedId(bed.Id);

                if (client is not null)
                {
                    if (client.CheckOutDate < DateTime.Now || client.CheckOutDate < DateTime.Now.Subtract(TimeSpan.FromHours(1)))
                        ColorBed(bed.Id, Brushes.Red);
                    else if (client.CheckOutDate < DateTime.Now.Subtract(TimeSpan.FromHours(2)))
                        ColorBed(bed.Id, Brushes.Yellow);
                    else
                        ColorBed(bed.Id, Brushes.Gray);
                }
                else
                {
                    ColorBed(bed.Id, Brushes.White);
                }
            }
        }
    }

    private void ColorBed(int bedId, Brush color) => _bedButtons.First(c => Convert.ToInt32(c.Tag) == bedId).Background = color;
    #endregion
}