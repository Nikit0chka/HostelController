using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HostelController;

public partial class CurrentRoomStatus : Page
{
    public CurrentRoomStatus()
    {
        InitializeComponent();
    }

    private void RoomOne_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Room(1));
    }
}
