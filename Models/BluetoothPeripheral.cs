namespace TSDZ2Monitor.Models;

public partial class BluetoothPeripheral : ObservableObject
{
  public string       Name    { get; set; }
  public string       DeviceName { get; set; }
  public string       Id { get; set; } 
  public int          Rssi { get; set; } 
  public string       State { get; set; } 
  public int          AdvertisementCount { get; set; }

  private bool        cancelBinIsVisible;
  public bool         CancelBinIsVisible { 
    get => cancelBinIsVisible; 
    set => SetProperty(ref cancelBinIsVisible, value); 
  }

}
