namespace TSDZ2Monitor.ViewModels;

public partial class TracksViewModel : ObservableObject
{
  IGeolocation geolocation;
  IMap map;
  public TracksViewModel(IGeolocation geolocation, IMap map)  //with dependency injection
  {
    this.geolocation = geolocation;
    this.map= map;
  }

  [ObservableProperty]
  private bool isBusy = false;

  [RelayCommand]
  public async void GetLocation()
  {
    Location location = null;
    try
    {
      IsBusy = true;
      location = await geolocation.GetLocationAsync(new GeolocationRequest
      {
        DesiredAccuracy = GeolocationAccuracy.Best,
        Timeout = TimeSpan.FromSeconds(30)
      });
      IsBusy = false;
      //await Application.Current.MainPage.DisplayAlert("Location", $"{location.Latitude} {location.Longitude} {location.Altitude} {location.Speed}", "OK");
    }
    catch (Exception e)
    {
      Debug.WriteLine($"GM: Can't query location: {e.Message}");
      await Application.Current.MainPage.DisplayAlert("GM: Error", e.Message, "OK");
    }

    if (location != null)
    {
      MapLaunchOptions options = new MapLaunchOptions {
        Name = "Start",
        NavigationMode = NavigationMode.None //.Bicycling
      };

      Placemark placemark = new Placemark
      {
        CountryName = "United Kingdom",
        AdminArea = "Stoke-on-Trent",
        Thoroughfare = "Hanley",
        Locality = "Stoke-on-Trent"
      };

      try
      {
        //await map.OpenAsync(location, options);
        await Map.Default.OpenAsync(placemark, options);
      }
      catch (Exception e)
      {
        Debug.WriteLine($"GM: Ooops map issue: {e.Message}");
      }
    }
  }
}
