namespace TSDZ2Monitor.ViewModels;

[QueryProperty(nameof(TracksPolyline), "TracksPolyline")]

public partial class TracksListViewModel : ObservableObject 
{
  public TracksListViewModel()
  {
    LoadExistingTracks();
  }

  [ObservableProperty]
  private Polyline tracksPolyline;

  [ObservableProperty]
  private Track selectedItem;

  [ObservableProperty]
  private ObservableCollection<Track> tracks = new();

  [ObservableProperty]
  private string trackName;

  [ObservableProperty]
  private bool trackNameEntryEnabled = true;

  private async void LoadExistingTracks()
  {
    List<Track> l = await App.Database.GetTracksAsync();
    Tracks = new ObservableCollection<Track>(l);
  }

  [RelayCommand]
  public async void SelectionChanged()
  {
    if (SelectedItem == null) return;
    //Debug.WriteLine($"{SelectedItem.Name}: {SelectedItem.BikePolyline}");

    //pass the polyline back to the TracksPage and display it
    MessagingCenter.Send(new MessagingMarker(), "LoadTrack", SelectedItem.BikePolyline);
    await Shell.Current.GoToAsync("..");

    //clear selection
    SelectedItem = null;
  }

  [RelayCommand]
  public void AddTrack()
  {
    AddTrackToList();
  }

  public void AddTrackToList()
  { 
    if (TrackName == String.Empty) return;
    //should check for name in db really
    foreach (Track tr in Tracks)
    {
      if (tr.Name == TrackName)
      {
        TrackName = "Duplicate Name - try again";
        return;
      }
    }

    //process the polyline to a JSON string of coordinates so as to store in SQLite
    string coordsJson = "[";
    for (int i = 0; i < TracksPolyline.Positions.Count; i++)
    {
      if (i == 0) coordsJson += $"{{\"Longitude\" : {TracksPolyline.Positions[i].Longitude}, \"Latitude\": {TracksPolyline.Positions[i].Latitude}}}";
      else        coordsJson += $", {{\"Longitude\" : {TracksPolyline.Positions[i].Longitude}, \"Latitude\": {TracksPolyline.Positions[i].Latitude}}}";
    }
    coordsJson += "]";
    Track t = new()
    {
      Name = TrackName,
      BikePolyline = coordsJson,
    };

    //add to db and to ObservableCollection
    App.Database.InsertTrackAsync(t);
    Tracks.Add(t);

    //dismiss keyboard
    TrackNameEntryEnabled = false;
    TrackNameEntryEnabled = true;

    //clear text from entry
    TrackName = String.Empty;
  }

  //remove peripheral
  [RelayCommand]
  public async void DeleteTrack(Track t)
  {
    //need to find the actual item in the list otherwise changes are not updated in ui
    foreach (Track q in Tracks)
    {
      if (Equals(t, q))
      {
        if (!q.CancelBinIsVisible)
        {
          q.CancelBinIsVisible = true;
        }
        else
        {
          q.CancelBinIsVisible = false;
          Tracks.Remove(q);
          await App.Database.DeleteTrackAsync(q);
        }
        break;
      }
    }
  }

  //remove peripheral
  [RelayCommand]
  public static void CancelDeleteTrack(Track t)
  {
    t.CancelBinIsVisible = false;
  }

  [RelayCommand]
  public void TrackNameReturn()
  {
    AddTrackToList();
  }

}
