using DataBaseModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace HostelController;

public partial class Room : Page
{
    private int _id;
    private List<Bed> _beds;
    private DataBaseContext _dbContext;
    private Dictionary<int, Button> _bedButtons;

    public Room(int roomId)
    {
        _id = roomId;
        _bedButtons = new Dictionary<int, Button>();
        _dbContext = new DataBaseContext();
        _beds = _dbContext.Rooms.Where(c => c.Id == _id).Select(c => c.Beds).ToList().First();

        InitializeComponent();
        InitializeBeds();
        //  CheckBedStatus();
    }

    private void InitializeBeds()
    {
        Dictionary<HorizontalAlignment, VerticalAlignment> placement = new Dictionary<HorizontalAlignment, VerticalAlignment>
        { { HorizontalAlignment.Left, VerticalAlignment.Top },{ HorizontalAlignment.Right, VerticalAlignment.Top},
            { HorizontalAlignment.Left, VerticalAlignment.Bottom }, { HorizontalAlignment.Right, VerticalAlignment.Bottom } };
        int index = 0;
        foreach (var bed in _beds)
        {
            Button bedButton = new Button
            {
                Name = "Bed" + bed.Id.ToString(),
                Content = "Кровать " + bed.Id.ToString(),
                Style = (Style) Application.Current.Resources["MahApps.Styles.Button.Square"],
                Height = 80,
                Width = 150,
                HorizontalAlignment = placement.Keys.ElementAt(index),
                VerticalAlignment = placement.Values.ElementAt(index),
                FontSize = 16
            };
            index++;
            Content = bedButton;
            _bedButtons.Add(bed.Id, bedButton);
        }

    }

    private void OpenRegistrationPageOnClick(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new RegistratePage());
    }

    private void ColorBed(int bedId, Brush color)
    {
        _bedButtons[bedId].Background = color;
    }

    private async void CheckBedStatus()
    {
        Client client = _dbContext.Clients.Where(c => c.Id == _id).First();

        await Task.Run(() =>
        {
            while (IsLoaded)
                foreach (var bed in _beds)
                {
                    if (bed.IsOccupied)
                    {
                        if (client.CheckOutDate < DateTime.Now)
                            ColorBed(bed.Id, Brushes.Red);
                        if (client.CheckOutDate < DateTime.Now.Subtract(TimeSpan.FromMinutes(10)))
                            ColorBed(bed.Id, Brushes.Yellow);
                        else
                            ColorBed(bed.Id, Brushes.Gray);
                    }
                    else
                        ColorBed(bed.Id, Brushes.White);
                }
        });
    }
}
