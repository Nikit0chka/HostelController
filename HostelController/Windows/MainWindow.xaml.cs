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

    private void ShowBookingButt_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new BookingPage());

    #endregion
    #region Logic
    private void CheckBedsStatus()
    {
        foreach (CurrentClient client in DataBaseController.GetClientsList())
        {
            TimeSpan remainigClientTime = client.CheckOutDate - DateTime.Now;

            if (remainigClientTime < TimeSpan.FromHours(6))
                EditExclamationTxtBlck(Brushes.Red, "!!");
            else if (remainigClientTime < TimeSpan.FromHours(3))
                EditExclamationTxtBlck(Brushes.Yellow, "!");
            else
                EditExclamationTxtBlck(Brushes.Gray, "");

            UpdateAllRoomInfoIfOpen();
        }
    }

    private void StartTimer()
    {
        DispatcherTimer _timer = new();
        _timer.Tick += (sender, e) => CheckBedsStatus();
        _timer.Start();
        _timer.Interval = TimeSpan.FromMinutes(1);
    }

    public Page GetActivePage() => (Page) MainFrame.Content;

    private void EditExclamationTxtBlck(Brush color, string text) => Application.Current.Dispatcher.Invoke
        (() =>
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