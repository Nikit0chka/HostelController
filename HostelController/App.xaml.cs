using HostelController.DataBaseModels;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace HostelController;

public partial class App : Application
{
    public static StringBuilder GetValidationErrors(DependencyObject container)
    {
        StringBuilder errorContent = new();

        foreach (object? child in LogicalTreeHelper.GetChildren(container))
        {
            if (child is not DependencyObject element)
                continue;

            if (Validation.GetHasError(element))
            {
                errorContent.Append("Найдена ошибка:\r\n");
                foreach (ValidationError error in Validation.GetErrors(element))
                {
                    errorContent.Append(error.ErrorContent.ToString());
                    errorContent.Append("\r\n");
                }
            }

            errorContent.Append(GetValidationErrors(element));
        }

        return errorContent;
    }

    public static void ShowMessageBox(string title, string message)
    {
        MetroWindow? currentWindow = Current.Windows.OfType<MetroWindow>().SingleOrDefault(x => x.IsActive);
        if (currentWindow is null)
            return;

        currentWindow.ShowMessageAsync(title, message);
    }

    public static TextBlock GetBedStatusTextBlockByRoomId(int roomId)
    {
        foreach (Bed bed in DataBaseController.GetBedsListByRoomId(roomId))
        {
            Client client = DataBaseController.GetClientByBedId(bed.Id);

            if (client is null)
                continue;

            TimeSpan remainigClientTime = client.CheckOutDate - DateTime.Now;

            if (remainigClientTime < TimeSpan.FromMinutes(30))
                return new TextBlock { Text = "!!", Foreground = Brushes.Red };
            else if (remainigClientTime < TimeSpan.FromHours(1))
                return new TextBlock { Text = "!", Foreground = Brushes.Yellow };
        }

        return new TextBlock();
    }

    private void StartTimer()
    {
        DispatcherTimer _timer = new();
        _timer.Tick += (sender, e) => CheckBedsStatus();
        _timer.Interval = TimeSpan.FromMinutes(1);
        _timer.Start();
    }

    private void CheckBedsStatus()
    {

    }
}
