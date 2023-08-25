using HostelController.DataBaseModels;
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

}
