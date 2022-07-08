namespace TSDZ2Monitor.Models;

public partial class BluetoothData : ObservableObject
{
  //Heart rate raw data
  public int HRM { get; set; }
  public double HRR { get; set; }

  //SPD raw data
  public int SPDWheelRevolutions { get; set; }
  public double SPDWheelEventTime { get; set; }

  //CAD raw data
  public int CADCrankRevolutions { get; set; }
  public double CADCrankEventTime { get; set; }

}
