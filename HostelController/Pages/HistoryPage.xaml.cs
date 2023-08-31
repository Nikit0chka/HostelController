using HostelController.DataBaseModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace HostelController.Pages;

public partial class HistoryPage : Page
{
    public HistoryPage()
    {
        InitializeComponent();

        InitializeDataGridContent();
    }

    public void InitializeDataGridContent() => ClientsHistoryDataGrid.ItemsSource = DataBaseController.GetClientsHistories();

    private void DeleteHistoryButt_Click(object sender, RoutedEventArgs e)
    {
        List<object> selectedItems = new();

        foreach (object item in ClientsHistoryDataGrid.Items)
        {
            DataGridRow row = (DataGridRow) ClientsHistoryDataGrid.ItemContainerGenerator.ContainerFromItem(item);
            if (row != null)
            {
                if (ClientsHistoryDataGrid.Columns[0] is DataGridCheckBoxColumn checkBox)
                {
                    FrameworkElement element = checkBox.GetCellContent(row);
                    if (element is CheckBox cb && cb.IsChecked == true)
                        selectedItems.Add(item);

                }
            }
        }

        selectedItems.ForEach(c => DataBaseController.DeleteClientHistory(c as ClientsHistory));

        if (selectedItems.Count > 0)
            App.ShowMessageBox("", "История удалена успешно!");

        InitializeDataGridContent();
    }
}
