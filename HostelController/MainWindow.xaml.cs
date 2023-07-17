using DataBaseModels;
using MahApps.Metro.Controls;

using System.Windows;

namespace HostelController;

public partial class MainWindow : MetroWindow
{
    private RegistratePage _registratePage;
    private CurrentRoomStatus _currentRoomStatus;
    private DataBaseContext _dbContext = new DataBaseContext();

    public MainWindow()
    {
        InitializeComponent();

        _registratePage = new RegistratePage();
        _currentRoomStatus = new CurrentRoomStatus();
    }

    private void InitializeBD()
    {
        for(int i = 0; i < 3;  i++)
        {
            Bed bed = new Bed();
            _dbContext.Beds.Add(bed);
        }
    }

    private void AddClientButt_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(_registratePage);
    }

    private void ShowRoomsButt_Click(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(_currentRoomStatus);
    }
}