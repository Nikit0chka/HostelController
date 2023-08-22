using MahApps.Metro.Controls;

using System.Windows;

namespace HostelController;

public partial class MainWindow : MetroWindow
{
    public MainWindow()
    {
        InitializeComponent();

        MainFrame.Navigate(new CurrentRoomStatus());
    }

    private void ShowRoomsButt_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new CurrentRoomStatus());
    }
}