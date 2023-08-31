using HostelController.DataBaseModels;
using HostelController.Pages;
using MahApps.Metro.Controls;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace HostelController;

public partial class MainWindow : MetroWindow
{
    public MainWindow()
    {
        Initialized += MainWindow_Initialized;

        InitializeComponent();
    }

    #region Events
    private void MainWindow_Initialized(object? sender, EventArgs e)
    {
        StartTimer();

        MainFrame.Navigate(new AllRoomsInfoPage());
    }

    private void ShowRoomsButt_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new AllRoomsInfoPage());

    private void ShowHistoryButt_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new HistoryPage());
    private void ShowRegistrateButt_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new RegistratePage());

    private void ShowBookingButt_Click(object sender, RoutedEventArgs e)
    {
        //
    }
    #endregion
    #region Logic
    private void CheckBedsStatus()
    {
        foreach (Client client in DataBaseController.GetClientsList())
        {
            TimeSpan remainigClientTime = client.CheckOutDate - DateTime.Now;

            if (remainigClientTime < TimeSpan.FromMinutes(30))
            {
                EditExclamationTxtBlck(Brushes.Red, "!!");
                UpdateAllRoomInfoIfOpen();
                return;
            }
            else if (remainigClientTime < TimeSpan.FromHours(1))
            {
                EditExclamationTxtBlck(Brushes.Yellow, "!");
                UpdateAllRoomInfoIfOpen();
                return;
            }
        }

        EditExclamationTxtBlck(Brushes.Gray, "");
    }

    private void StartTimer()
    {
        DispatcherTimer _timer = new();
        _timer.Tick += (sender, e) => CheckBedsStatus();
        _timer.Start();
        _timer.Interval = TimeSpan.FromSeconds(1);
    }

    public Page GetActivePage() => MainFrame.Content as Page;

    private void EditExclamationTxtBlck(Brush color, string text) => Application.Current.Dispatcher.Invoke(() =>
                                                     {
                                                         ExclamationTxtBlck.Text = text;
                                                         ExclamationTxtBlck.Foreground = color;
                                                     });

    private void UpdateAllRoomInfoIfOpen()
    {
        if (MainFrame.Content is Page currentPage && currentPage.GetType() == typeof(AllRoomsInfoPage))
            MainFrame.Navigate(new AllRoomsInfoPage());
    }
    #endregion
}