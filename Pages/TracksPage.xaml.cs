using GoogleGson;

namespace TSDZ2Monitor.Pages;

public partial class TracksPage : ContentPage
{
	public TracksPage(TracksViewModel viewModel, IGeolocation geolocation)
	{
		InitializeComponent();
    BindingContext = viewModel;

    //setup a timer for interrogating location every second
    timer.AutoReset = true;
    timer.Elapsed += OnTimedEvent;

    this.geolocation = geolocation;

    Setup();

    //message from TacksList page to load a new track
    MessagingCenter.Subscribe<MessagingMarker, string>(this, "LoadTrack", (sender, arg) =>
    {
      //load polyline
      //Debug.WriteLine($"Polyline {arg}");
      mapView.Drawables.Clear();
      pl = new() { StrokeWidth = 4, StrokeColor = Colors.Red };

      //deserialize json and cycle through it
      try
      {
        var a = JsonSerializer.Deserialize<List<BikePos>>(arg);
        foreach(BikePos p in a)
        {
          pl.Positions.Add(new(p.Latitude, p.Longitude));
        }
      }
      catch(Exception e)
      {
        Debug.WriteLine(e.Message);
      }

      mapView.Drawables.Add(pl);
    });

  }

  readonly IGeolocation geolocation;

  public Location location = new();

  public MapControl mapControl;

  public Polyline pl;

  private static readonly System.Timers.Timer timer = new(1000);

  public async void Setup()
  {
    try
    {
      ActIndicator.IsRunning = true;
      location = await geolocation.GetLocationAsync(new GeolocationRequest
      {
        DesiredAccuracy = GeolocationAccuracy.Best,
        Timeout = TimeSpan.FromSeconds(30)
      });
      ActIndicator.IsRunning = false;
    }
    catch (Exception e)
    {
      Debug.WriteLine($"GM: Can't get location: {e.Message}");
    }

    ActIndicator.IsRunning = true;
    //setup Mapsui map
    mapControl = new Mapsui.UI.Maui.MapControl();
    mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());

    //link to xaml
    mapView.Map = mapControl.Map;
    ActIndicator.IsRunning = false;


    //Navigate to my location
    var (x, y) = SphericalMercator.FromLonLat(location.Longitude, location.Latitude);
    mapView.Navigator.NavigateTo(new MPoint(x, y), mapControl.Map.Resolutions[16]);

    //Add pin at current position
    BikePosition p = new()
    {
      Latitude = location.Latitude,
      Longitude = location.Longitude
    };
    AddPin(p, Colors.Blue);

    //Start polyline
    pl = new() { StrokeWidth = 4, StrokeColor = Colors.Red };

    pl.Positions.Add(new((float)location.Latitude, (float)location.Longitude));
  }


  //If timed event fires then get current position and navigate to that position adding a polyline
  private async void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
  {
    //get new location
    try
    {
      location = await geolocation.GetLocationAsync(new GeolocationRequest
      {
        DesiredAccuracy = GeolocationAccuracy.Best,
        Timeout = TimeSpan.FromSeconds(60)  //enough?
      });
      
      Debug.WriteLine($"{location.Longitude} {location.Latitude}");

      //add pin at current location
      mapView.Pins.Clear();
      mapView.Drawables.Clear();

      //Navigate to my location
      var (x, y) = SphericalMercator.FromLonLat(location.Longitude, location.Latitude);
      //mapView.Navigator.NavigateTo(new MPoint(x, y), mapControl.Map.Resolutions[14]);  //0 zoomed out-19 zoomed in
      mapView.Navigator.CenterOn(new MPoint(x, y));

      BikePosition p = new()
      {
        Latitude = location.Latitude,
        Longitude = location.Longitude
      };
      AddPin(p, Colors.Red);

      //add track using polyline
      pl.Positions.Add(new((float) location.Latitude, (float) location.Longitude));
      mapView.Drawables.Add(pl);
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"GM: Can't get location: {ex.Message}");
    }

  }

  public void AddPin(BikePosition p, Color c)
  {
    var myPin = new Pin(mapView)
    {
      Position = new Position(p.Latitude, p.Longitude),
      Type = PinType.Pin,
      Label = $"",
      Scale = 0.7F,
      Color = c,
    };
    mapView.Pins.Add(myPin);
  }

  private void Tracking(object sender, EventArgs e)
  {
    if (TrackingButton.Text == "Stop")
    {
      TrackingButton.Text = "Start";
      TrackingButton.BackgroundColor = Colors.Green;
      timer.Stop();
    }
    else
    {
      TrackingButton.Text = "Stop";
      TrackingButton.BackgroundColor = Colors.Red;
      timer.Start();
    }
  }

  private async void SaveTrack(object sender, EventArgs e)
  {
    //navigate to TracksList page and pass in the current polyline
    //pause the timer?
    TrackingButton.Text = "Start";
    TrackingButton.BackgroundColor = Colors.Green;
    timer.Stop();

    var navigationParameter = new Dictionary<string, object>
    {
        { "TracksPolyline", pl }
    };
    await Shell.Current.GoToAsync(nameof(TracksListPage), true, navigationParameter);

  }

  private void ClearTrack(object sender, EventArgs e)
  {
    //stop timer
    TrackingButton.Text = "Start";
    TrackingButton.BackgroundColor = Colors.Green;
    timer.Stop();

    //create new polyline
    pl = new() { StrokeWidth = 4, StrokeColor = Colors.Red };
    pl.Positions.Add(new((float)location.Latitude, (float)location.Longitude));

    mapView.Pins.Clear();
    mapView.Drawables.Clear();

    //add current position pin
    BikePosition p = new()
    {
      Latitude = location.Latitude,
      Longitude = location.Longitude
    };
    AddPin(p, Colors.Red);

  }
}

public class BikePos
{
  public float Latitude { get; set; }
  public float Longitude { get; set; }
}