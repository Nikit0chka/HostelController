using HostelController.DataBaseModels;
using HostelController.Windows;
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

        App.ShowMessageBox("", "Гость выселен успешно!");

        NavigationService.GoBack();
    }

    private void OpenRegistratePage(object sender, RoutedEventArgs e) => NavigationService.Navigate(new RegistratePage(_chosedBed.Id));

    private void OpenExtendClientStayWindow(object sender, RoutedEventArgs e)
    {
        ExtendClientStayWindow extendClientStayWindow = new(_chosedBedClient.Id);
        extendClientStayWindow.Show();

        extendClientStayWindow.Closed += (sender, args) => InitializeContent();
    }
    #endregion

    #region Logic
    private void InitializeContent()
    {
        ButtonStckPan.Children.Clear();
        RoomNumber.Text = $"Комната {_chosedBed.RoomId}";
        BedNumber.Text = $"Кровать {_chosedBed.Number}";

        if (_chosedBedClient is not null)
        {
            InitializeBedInfo();
            InitializeEvictClientButt();
            CalculateRemainingTimeOfStayAsync();
            InitializeExtendClientStayButt();
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
            Height = 70,
            Width = 140,
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
            Height = 70,
            Width = 140,
            FontSize = 16,
            BorderThickness = new Thickness(0),
            Margin = new Thickness(10)
        };
        EvictClientButt.Click += new RoutedEventHandler(EvictClient);

        ButtonStckPan.Children.Add(EvictClientButt);
    }

    private void InitializeExtendClientStayButt()
    {
        Button ExtendClientStayButt = new()
        {
            Content = "Продлить",
            Style = (Style) Application.Current.Resources["MahApps.Styles.Button.Square.Accent"],
            Height = 70,
            Width = 140,
            FontSize = 16,
            BorderThickness = new Thickness(0),
            Margin = new Thickness(10)
        };
        ExtendClientStayButt.Click += new RoutedEventHandler(OpenExtendClientStayWindow);

        ButtonStckPan.Children.Add(ExtendClientStayButt);
    }

    private async void CalculateRemainingTimeOfStayAsync()
    {
        MainWindow currentWindow = Application.Current.Windows.OfType<MetroWindow>().SingleOrDefault(x => x.IsActive) as MainWindow;
        Page currentPage = currentWindow.GetActivePage();

        while (currentPage.GetType() == GetType() || currentPage.GetType() == new CurrentRoomInfoPage(_chosedBed.RoomId).GetType())
        {
            TimeSpan remainingTime = _chosedBedClient.CheckOutDate - DateTime.Now;
            int remainingDays = remainingTime.Days;

            RemainingTimeOfStay.Text = $"Оставшееся время : {remainingDays} дней  {remainingTime:hh\\:mm\\:ss} часов";

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