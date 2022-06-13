namespace TSDZ2Monitor.Models;

public class BluetoothPeripheral
{
  public string       Name    { get; set; }
  public string       DeviceName { get; set; }
  public string       Id { get; set; } 
  public int          Rssi { get; set; } 
  public string       State { get; set; } 
  public int          AdvertisementCount { get; set; } 

}
