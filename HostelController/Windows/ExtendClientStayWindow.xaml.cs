using HostelController.DataBaseModels;
using MahApps.Metro.Controls;
using System.Windows;

namespace HostelController.Windows;

public partial class ExtendClientStayWindow : MetroWindow
{
    private readonly Client _client;
    public ExtendClientStayWindow(int clientId)
    {
        DisableMainWindow();
        _client = DataBaseController.GetCLientById(clientId);

        Closed += ExtendClientStayWindow_Closed;

        InitializeComponent();
    }

    #region Events
    private void ExtendClientStayWindow_Closed(object? sender, System.EventArgs e) => EnableMainWindow();
    #endregion

    #region Logic
    private static void DisableMainWindow() => Application.Current.MainWindow.IsEnabled = false;

    private static void EnableMainWindow() => Application.Current.MainWindow.IsEnabled = true;

    private void AcceptButton_Click(object sender, RoutedEventArgs e)
    {
        DataBaseController.UpdateClientStay(_client.Id, _client.CheckOutDate.AddDays((double) ValueOfDays.Value));

        App.ShowMessageBox("", "Дата проживания продлена!");

        Close();
    }
    #endregion
}
