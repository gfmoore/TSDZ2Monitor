namespace TSDZ2Monitor.ViewModels;

public partial class Display2PageViewModel : ObservableObject
{
  public Display2PageViewModel()
  {
    BTData = new BluetoothData();

    MessagingCenter.Subscribe<MessagingMarker, BluetoothData>(this, "BTDataUpdate", (sender, arg) =>
    {
      //Debug.WriteLine($"Message received {arg}");
      BTData.HRM                   = arg.HRM;
      BTData.HRR                   = arg.HRR;
      BTData.SPDWheelRevolutions   = arg.SPDWheelRevolutions;
      BTData.SPDWheelEventTime     = arg.SPDWheelEventTime;
      BTData.WheelRPM              = arg.WheelRPM;
      BTData.CADCrankRevolutions   = arg.CADCrankRevolutions;
      BTData.CADCrankEventTime     = arg.CADCrankEventTime;
      BTData.Cadence               = arg.Cadence;
    });

  }

  [ObservableProperty]
  private string test="Testing";

  [ObservableProperty]
  private BluetoothData bTData;


}