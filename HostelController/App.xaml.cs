using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HostelController;

public partial class App : Application
{
    public static StringBuilder GetValidationErrors(DependencyObject container)
    {
        StringBuilder errorContent = new StringBuilder();

        foreach (var child in LogicalTreeHelper.GetChildren(container))
        {
            DependencyObject element = child as DependencyObject;

            if (element == null)
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
        var currentWindow = Current.Windows.OfType<MetroWindow>().SingleOrDefault(x => x.IsActive);

        currentWindow.ShowMessageAsync(title, message);
    }
}
