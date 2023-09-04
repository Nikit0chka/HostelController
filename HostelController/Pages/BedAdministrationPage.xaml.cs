using HostelController.DataBaseModels;
using HostelController.Windows;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HostelController.Pages;

public partial class BedAdministrationPage : Page
{
    private readonly Bed? _chosedBed;
    private readonly CurrentClient? _chosedBedClient;
    private CancellationTokenSource _cts;

    public BedAdministrationPage(int bedId)
    {
        _chosedBed = DataBaseController.GetBedById(bedId);
        _chosedBedClient = DataBaseController.GetClientByBedId(bedId);
        _cts = new CancellationTokenSource();

        InitializeComponent();
        InitializeContentByToogleSwitchStatus();
    }

    #region Events
    private void EvictClient(object sender, RoutedEventArgs e)
    {
        if (_chosedBed is not null && _chosedBedClient is not null)
            DataBaseController.RemoveClientById(_chosedBedClient.Id);

        App.ShowMessageBox("", "Гость выселен успешно!");

        NavigationService.GoBack();
    }

    private void OpenRegistratePage(object sender, RoutedEventArgs e)
    {
        if (_chosedBed is not null)
            NavigationService.Navigate(new RegistratePage(_chosedBed.Id));
    }

    private void OpenExtendClientStayWindow(object sender, RoutedEventArgs e)
    {
        if (_chosedBed is not null && _chosedBedClient is not null)
        {
            ExtendClientStayWindow? extendClientStayWindow = new(_chosedBedClient.Id);
            extendClientStayWindow.Show();

            extendClientStayWindow.Closed += (sender, args) => InitializeBedStatusContent();
        }
    }

    private void ContentTypeToggleSwitch_Toggled(object sender, RoutedEventArgs e) => InitializeContentByToogleSwitchStatus();
    #endregion

    #region Logic
    private void InitializeContentByToogleSwitchStatus()
    {
        if (ContentTypeToggleSwitch.IsOn)
        {
            _cts.Cancel();
            InitializeBedBookingContent();
        }
        else
        {
            _cts = new CancellationTokenSource();
            InitializeBedStatusContent();
        }
    }

    private void InitializeBedStatusContent()
    {
        ButtonStckPan.Children.Clear();
        if (_chosedBed is not null)
        {
            RoomNumber.Text = $"Комната {_chosedBed.RoomId}";
            BedNumber.Text = $"Кровать {_chosedBed.Number}";
            BedStatucTxtBlc.Text = "Свободна";
        }

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

    private void InitializeBedBookingContent()
    {
        if (_chosedBed is not null)
        {
            BedInfoUnifGrid.Children.Clear();
            RemainingTimeOfStay.Text = "";

            List<ClientBooking>? clientBookings = DataBaseController.GetClientBookingsByBedId(_chosedBed.Id);

            if (clientBookings is null || clientBookings.Count <= 0)
            {
                BedStatucTxtBlc.Text = "Бронирований нет";
            }
            else
            {
                ////DataGrid dataGrid = new() { HorizontalAlignment = HorizontalAlignment.Center, AutoGenerateColumns = false };
                //dataGrid.colums
            }
        }
    }

    private void InitializeBedInfo()
    {
        if (_chosedBedClient is not null)
        {
            BedStatucTxtBlc.Text = "Занята";
            BedInfoUnifGrid.Children.Clear();
            BedInfoUnifGrid.Columns = 2;

            BedInfoUnifGrid.Children.Add(new TextBlock { Text = $"Имя : {_chosedBedClient.Name}" });
            BedInfoUnifGrid.Children.Add(new TextBlock { Text = $"Фамилия: {_chosedBedClient.Surname}" });
            BedInfoUnifGrid.Children.Add(new TextBlock { Text = $"Время заезда : {_chosedBedClient.CheckInDate:t}" });
            BedInfoUnifGrid.Children.Add(new TextBlock { Text = $"Дата заезда : {_chosedBedClient.CheckInDate:d}" });
            BedInfoUnifGrid.Children.Add(new TextBlock { Text = $"Время выезда : {_chosedBedClient.CheckOutDate:t}" });
            BedInfoUnifGrid.Children.Add(new TextBlock { Text = $"Дата выезда : {_chosedBedClient.CheckOutDate:d}" });
        }
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
        MainWindow? currentWindow = Application.Current.Windows.OfType<MetroWindow>().SingleOrDefault(x => x.IsActive) as MainWindow;

        if (currentWindow is not null && _chosedBed is not null && _chosedBedClient is not null)
        {
            Page currentPage = currentWindow.GetActivePage();

            while (currentPage.GetType() == GetType() || currentPage.GetType() == new CurrentRoomInfoPage(_chosedBed.RoomId).GetType())
            {
                if (_cts.IsCancellationRequested)
                    break;

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
    }
    #endregion
}