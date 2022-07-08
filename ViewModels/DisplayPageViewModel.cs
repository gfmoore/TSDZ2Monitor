namespace TSDZ2Monitor.ViewModels;

public partial class DisplayPageViewModel : ObservableObject
{
  public DisplayPageViewModel()
  {
    //Btd = BluetoothPeripheralsViewModel.
    //btd.HRM = 76;
    //btd.HRR = 0.76523;

    //btd.SPDWheelRevolutions = 376543;
    //btd.SPDWheelEventTime = 0.65087;

    //btd.CADCrankRevolutions = 43;
    //btd.CADCrankEventTime = 0.0765;
  }

  [ObservableProperty]
  private string test="Testing";

  [ObservableProperty]
  private BluetoothData btd = new();

}