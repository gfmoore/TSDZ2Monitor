namespace TSDZ2Monitor.ViewModels;

[QueryProperty(nameof(BluetoothPeripheral), "BluetoothPeripheral")]
public partial class BluetoothPeripheralsDetailViewModel : ObservableObject
{
  public BluetoothPeripheralsDetailViewModel()
  {
    Debug.WriteLine("hi");
  }

  [ObservableProperty]
  private BluetoothPeripheral bluetoothPeripheral;

}
