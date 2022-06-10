namespace TSDZ2Monitor.ViewModels;

public partial class BluetoothPeripheralsViewModel : ObservableObject
{
  [ObservableProperty]
  public ObservableCollection<BluetoothPeripheral> bluetoothPeripherals = new()
  {
    new BluetoothPeripheral
    {
      Name = "Heart Rate Monitor",
      Id = "12:12:12:12:AB",
      Enabled = true
    },
    new BluetoothPeripheral
    {
      Name = "Speedometer",
      Id = "34:34:34:34:CD",
      Enabled = true
    },
    new BluetoothPeripheral
    {
      Name = "Cadence",
      Id = "56:56:56:56:EF",
      Enabled = true
    },
    new BluetoothPeripheral
    {
      Name = "TSDZ2Monitor Motor",
      Id = "78:78:78:78:GH",
      Enabled = true
    }
  };

  //remove peripeheral
  public ICommand DeleteBLEItemCommand => new Command<BluetoothPeripheral>(DeleteBLEItemControl);
  public void DeleteBLEItemControl(BluetoothPeripheral btp)
  {
    Console.WriteLine($"delete {btp.Name}");
    BluetoothPeripherals.Remove(btp);
  }
  
  //show details
  public ICommand ShowBLEItemCommand => new Command<BluetoothPeripheral>(ShowBLEItemControl);
  public void ShowBLEItemControl(BluetoothPeripheral btp)
  {
    Console.WriteLine($"You tapped on {btp.Name}");
  }



  [ObservableProperty]
  String scanButtonText = "Scan";

  [ObservableProperty]
  String scanResults = String.Empty;

  bool  scanning = false;

  //Scan for peripherals
  public ICommand ScanBLEPeripheralsCommand => new Command(ScanBLEPeripheralsControl);
  public void ScanBLEPeripheralsControl()
  {
    if (!scanning)
    {
      ScanButtonText = "Stop scan";
      ScanResults = "Scanning for BLE peripherals...";
      scanning = true;
      
    }
    else
    {
      ScanButtonText = "Scan";
      ScanResults = "";
      scanning = false;
    }
  }
}

