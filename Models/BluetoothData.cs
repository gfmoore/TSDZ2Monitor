namespace TSDZ2Monitor.Models;

public partial class BluetoothData : ObservableObject
{
  //Heart rate raw data
  private int hRM;
  public int HRM
  {
    get => hRM;
    set => SetProperty(ref hRM, value);
  }
  private double hRR;
  public double HRR
  {
    get => hRR;
    set => SetProperty(ref hRR, value);
  }

  //SPD raw data
  private int sPDWheelRevolutions;
  public int SPDWheelRevolutions
  {
    get => sPDWheelRevolutions;
    set => SetProperty(ref sPDWheelRevolutions, value);
  }
  private double sPDWheelEventTime;
  public double SPDWheelEventTime
  {
    get => sPDWheelEventTime;
    set => SetProperty(ref sPDWheelEventTime, value);
  }

  private double wheelRPM;
  public double WheelRPM
  {
    get => wheelRPM;
    set => SetProperty(ref wheelRPM, value);
  }

  //CAD raw data
  private int cADCrankRevolutions;
  public int CADCrankRevolutions
  {
    get => cADCrankRevolutions;
    set => SetProperty(ref cADCrankRevolutions, value);
  }
  private double cADCrankEventTime;
  public double CADCrankEventTime
  {
    get => cADCrankEventTime;
    set => SetProperty(ref cADCrankEventTime, value);
  }

  private double cadence;
  public double Cadence
  {
    get => cadence;
    set => SetProperty(ref cadence, value);
  }

}
