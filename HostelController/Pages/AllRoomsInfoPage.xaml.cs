using HostelController.DataBaseModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace HostelController.Pages;

public partial class AllRoomsInfoPage : Page
{
    private readonly DispatcherTimer _timer;

    public AllRoomsInfoPage()
    {
        Initialized += AllRoomsInfoPage_Initialized;
        Loaded += AllRoomsInfoPage_Loaded;
        _timer = new DispatcherTimer();

        InitializeComponent();
    }

    private void AllRoomsInfoPage_Loaded(object sender, RoutedEventArgs e)
    {
        InitializeRoomsButtons();
        StartTimer();
    }

    private void AllRoomsInfoPage_Initialized(object? sender, EventArgs e)
    {
        InitializeRoomsButtons();
        StartTimer();
    }

    private void StartTimer()
    {
        _timer.Tick += (sender, e) => InitializeRoomsButtons();
        _timer.Interval = TimeSpan.FromMinutes(1);
        _timer.Start();
    }

    private void InitializeRoomsButtons()
    {
        RoomButtUnifGrid.Children.Clear();
        foreach (Room room in DataBaseController.GetRoomsList())
        {
            StackPanel buttonContent = new();

            TextBlock roomNumber = new() { Text = $"Комната {room.Id}", HorizontalAlignment = HorizontalAlignment.Center };
            TextBlock roomFreeBedsCount = new() { Text = $"Свободно {DataBaseController.GetRoomFreeBedsCount(room.Id)}", HorizontalAlignment = HorizontalAlignment.Center };
            TextBlock roomStatus = App.GetBedStatusTextBlockByRoomId(room.Id);

            roomStatus.HorizontalAlignment = HorizontalAlignment.Center;

            buttonContent.Children.Add(roomNumber);
            buttonContent.Children.Add(roomFreeBedsCount);
            buttonContent.Children.Add(roomStatus);

            Button roomButt = new()
            {
                Name = $"Room{room.Id}",
                Style = (Style) Application.Current.Resources["MahApps.Styles.Button.Square.Accent"],
                Height = 85,
                Width = 125,
                FontSize = 16,
                BorderThickness = new Thickness(0),
                Margin = new Thickness(10),
                Padding = new Thickness(10),
                Tag = room.Id,
                Content = buttonContent
            };

            roomButt.Click += new RoutedEventHandler(OpenRoomInfoPage);
            RoomButtUnifGrid.Children.Add(roomButt);
        }
    }

    private void OpenRoomInfoPage(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new CurrentRoomInfoPage(Convert.ToInt32((sender as Button).Tag)));
        _timer.Stop();
    }
}
