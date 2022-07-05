namespace TSDZ2Monitor.ViewModels;

[QueryProperty(nameof(BluetoothPeripheral), "BluetoothPeripheral")]
public partial class BluetoothPeripheralsDetailViewModel : ObservableObject
{
  public BluetoothPeripheralsDetailViewModel()
  {
  }

  [ObservableProperty]
  private BluetoothPeripheral bluetoothPeripheral;

}
