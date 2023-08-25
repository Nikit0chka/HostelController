using HostelController.DataBaseModels;
using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HostelController.Pages;

public partial class BedAdministrationPage : Page
{
    private readonly Bed _chosedBed;
    private readonly Client _chosedBedClient;

    public BedAdministrationPage(int bedId)
    {
        _chosedBed = DataBaseController.GetBedById(bedId);
        _chosedBedClient = DataBaseController.GetClientByBedId(bedId);

        InitializeComponent();
        InitializeContent();
    }

    #region Events
    private void BedAdministrationPage_Loaded(object sender, RoutedEventArgs e) => CalculateRemainingTimeOfStayAsync();

    private void EvictClient(object sender, RoutedEventArgs e)
    {
        DataBaseController.RemoveClientById(_chosedBedClient.Id);

        NavigationService.GoBack();
    }

    private void OpenRegistratePage(object sender, RoutedEventArgs e) => NavigationService.Navigate(new RegistratePage(_chosedBed.Id));
    #endregion

    #region Logic
    private void InitializeContent()
    {
        RoomNumber.Text = $"Комната {_chosedBed.RoomId}";
        BedNumber.Text = $"Кровать {_chosedBed.Number}";

        if (_chosedBedClient is not null)
        {
            InitializeBedInfo();
            InitializeEvictClientButt();
            CalculateRemainingTimeOfStayAsync();
        }
        else
        {
            InitializeAddClientButt();
        }
    }

    private void InitializeBedInfo()
    {
        BedStatucTxtBlc.Text = "Занята";
        ClientName.Text = $"Имя : {_chosedBedClient.Name}";
        ClientSurname.Text = $"Фамилия: {_chosedBedClient.Surname}";
        TimeOfEntry.Text = $"Время заезда : {_chosedBedClient.CheckInDate:t}";
        DateOfEnty.Text = $"Дата заезда : {_chosedBedClient.CheckInDate:d}";
        TimeOfLeave.Text = $"Время выезда : {_chosedBedClient.CheckOutDate:t}";
        DateOfLeave.Text = $"Дата выезда : {_chosedBedClient.CheckOutDate:d}";
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

    private async void CalculateRemainingTimeOfStayAsync()
    {
        MainWindow currentWindow = Application.Current.Windows.OfType<MetroWindow>().SingleOrDefault(x => x.IsActive) as MainWindow;
        Page currentPage = currentWindow.GetActivePage();

        while (currentPage.GetType() == GetType() || currentPage.GetType() == new CurrentRoomInfoPage(_chosedBed.RoomId).GetType())
        {
            TimeSpan remainingTime = _chosedBedClient.CheckOutDate.TimeOfDay - DateTime.Now.TimeOfDay;
            RemainingTimeOfStay.Text = $"Оставшееся время : " + remainingTime.ToString(@"hh\:mm\:ss");

            if (_chosedBedClient.CheckOutDate < DateTime.Now)
            {
                RemainingTimeOfStay.Text = "Время проживания клиента истекло!";
                break;
            }

            currentPage = currentWindow.GetActivePage();
            await Task.Delay(1000);
        }
    }
    #endregion
}