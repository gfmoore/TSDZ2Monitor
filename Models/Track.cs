namespace TSDZ2Monitor.Models;

public partial class Track : ObservableObject
{
  [PrimaryKey, AutoIncrement]
  public int Id { get; set; }

  public string Name { get; set; }

  public string BikePolyline { get; set; }

  private bool cancelBinIsVisible;
  public bool CancelBinIsVisible
  {
    get => cancelBinIsVisible;
    set => SetProperty(ref cancelBinIsVisible, value);
  }

}
