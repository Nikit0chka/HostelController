using HostelController.DataBaseModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HostelController;

public partial class CurrentRoomStatus : Page
{
    private readonly DataBaseContext _dbContext;

    public CurrentRoomStatus()
    {
        _dbContext = new DataBaseContext();

        InitializeComponent();
        InitializeRoomsButtons();
    }

    private void InitializeRoomsButtons()
    {
        foreach (var room in _dbContext.Rooms.ToList())
        {
            Button roomButt = new Button
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
                Content = new TextBlock()
                {
                    Text = $"Комната {room.Id} Свободно {GetCountOFFreeBedsInRoom(room.Id)}",
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center,
                }
            };

            roomButt.Click += new RoutedEventHandler(OpenRoomInfoPage);
            RoomButtUnifGrid.Children.Add(roomButt);
        }
    }

    private int GetCountOFFreeBedsInRoom(int roomId)
    {
        return _dbContext.Beds.Where(c => c.RoomId == roomId && !c.IsOccupied).Count();
    }

    private void OpenRoomInfoPage(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new RoomInfoPage(Convert.ToInt32((sender as Button).Tag)));
    }
}
