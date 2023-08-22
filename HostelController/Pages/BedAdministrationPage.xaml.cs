using HostelController.DataBaseModels;
using System.Windows;
using System.Windows.Controls;

namespace HostelController;

public partial class BedAdministrationPage : Page
{
    private readonly Bed _chosedBed;
    private readonly Client? _chosedBedClient;

    public BedAdministrationPage(int bedId)
    {
        _chosedBed = DataBaseController.GetBedById(bedId);
        _chosedBedClient = DataBaseController.GetClientByBedId(bedId);

        InitializeComponent();
        InitializeContent();
    }

    private void InitializeContent()
    {
        RoomNumber.Text = $"Комната {_chosedBed.RoomId}";
        BedNumber.Text = $"Кровать {_chosedBed.Number}";

        if (_chosedBed.IsOccupied)
        {
            InitializeBedInfo();
            InitializeEvictClientButt();
        }
        else
            InitializeAddClientButt();
    }

    private void InitializeBedInfo()
    {
        BedStatucTxtBlc.Text = "Занята";
        TimeOfEntry.Text = _chosedBedClient.CheckInDate.TimeOfDay.ToString();
        DateOfEnty.Text = _chosedBedClient.CheckInDate.Date.ToString();
        TimeOfLeave.Text = _chosedBedClient.CheckOutDate.TimeOfDay.ToString();
        DateOfLeave.Text = _chosedBedClient.CheckOutDate.Date.ToString();
    }

    private void InitializeAddClientButt()
    {
        Button addLClientButt = new()
        {
            Content = "Добавить гостя",
            Style = (Style) Application.Current.Resources["MahApps.Styles.Button.Square.Accent"],
            Height = 85,
            Width = 150,
            FontSize = 16,
            BorderThickness = new Thickness(0)
        };
        addLClientButt.Click += new RoutedEventHandler(OpenRegistratePage);

        ButtonStckPan.Children.Add(addLClientButt);
    }

    private void InitializeEvictClientButt()
    {
        Button EvictClientButt = new()
        {
            Content = "Выселить гостя",
            Style = (Style) Application.Current.Resources["MahApps.Styles.Button.Square.Accent"],
            Height = 85,
            Width = 150,
            FontSize = 16,
            BorderThickness = new Thickness(0)
        };
        EvictClientButt.Click += new RoutedEventHandler(EvictClient);

        ButtonStckPan.Children.Add(EvictClientButt);
    }

    private void EvictClient(object sender, RoutedEventArgs e)
    {
        DataBaseController.RemoveClientById(_chosedBedClient.Id);

        NavigationService.Navigate(new CurrentRoomStatus());
    }

    private void OpenRegistratePage(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new RegistratePage(_chosedBed.Id));
    }
}