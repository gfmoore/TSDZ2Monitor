namespace TSDZ2Monitor.ViewModels;

public partial class BluetoothPeripheralsViewModel : ObservableObject
{
  bool scanning = false;

  [ObservableProperty]
  String scanButtonText = "Scan";

  [ObservableProperty]
  String scanResults = String.Empty;

  //create a list for remembered ble peripherals
  [ObservableProperty]
  public static ObservableCollection<BluetoothPeripheral> bluetoothPeripherals = new()
  {
    //new BluetoothPeripheral
    //{
    //  Name = "Heart Rate Monitor",
    //  Id = "12:12:12:12:AB",
    //  Enabled = true
    //},
    //new BluetoothPeripheral
    //{
    //  Name = "Speedometer",
    //  Id = "34:34:34:34:CD",
    //  Enabled = true
    //},
    //new BluetoothPeripheral
    //{
    //  Name = "Cadence",
    //  Id = "56:56:56:56:EF",
    //  Enabled = true
    //},
    new BluetoothPeripheral
    {
      Name = "TSDZ2Monitor Motor",
      DeviceName = "78:78:78:78:GH"
    }
  };

  //create a list for discovered ble peripherals
  [ObservableProperty]
  public static ObservableCollection<BluetoothPeripheral> discoveredPeripherals = new();


  //remove peripheral
  public ICommand DeleteBLEItemCommand => new Command<BluetoothPeripheral>(DeleteBLEItemControl);
  public void DeleteBLEItemControl(BluetoothPeripheral btp)
  {
    //Console.WriteLine($"delete {btp.Name}");
    BluetoothPeripherals.Remove(btp);
  }

  //remove peripheral
  public ICommand CancelDeleteBLEItemCommand => new Command<BluetoothPeripheral>(CancelDeleteBLEItemControl);
  public void CancelDeleteBLEItemControl(BluetoothPeripheral btp)
  {
    Console.WriteLine($"cancel delete {btp.Name}");
    //BluetoothPeripherals.Remove(btp);
  }

  //show details
  public ICommand ShowBLEItemCommand => new Command<BluetoothPeripheral>(ShowBLEItemControl);
  public void ShowBLEItemControl(BluetoothPeripheral btp)
  {
    //Console.WriteLine($"You tapped on {btp.Name}");
  }


  public ICommand ScanBLEPeripheralsCommand => new Command(ScanBLEPeripheralsControl);
  public async void ScanBLEPeripheralsControl()
  {
    var adapter = CrossBluetoothLE.Current.Adapter;
    //adapter.ScanTimeout = 20000; //assume ms
    if (!scanning)
    {
      ScanButtonText = "Stop scan";
      ScanResults = "Scanning for BLE peripherals...";
      scanning = true;

      adapter.DeviceDiscovered += (s, a) =>
      {
        if (a.Device.Name != null && a.Device.Name != String.Empty)
        {
          BluetoothPeripheral p = new()
          {
            Name                = a.Device.Name,
            DeviceName          = a.Device.NativeDevice.ToString(),
            Id                  = a.Device.Id.ToString(),
            State               = a.Device.State.ToString(),
            Rssi                = a.Device.Rssi,
            AdvertisementCount  = a.Device.AdvertisementRecords.Count
          };

          //need to see if peripheral in list
          bool found = false;
          foreach(BluetoothPeripheral q in DiscoveredPeripherals)
          {
            if (p.Name == q.Name)
            {
              found = true;
              break;
            }
          }

          if (!found) DiscoveredPeripherals.Add(p);

          //Console.WriteLine($"Bluetooth peripheral found:");
          //Console.WriteLine(a.Device.Name);
          //Console.WriteLine(a.Device.NativeDevice);
          //Console.WriteLine(a.Device.Id);
          //Console.WriteLine(a.Device.State);
          //Console.WriteLine(a.Device.Rssi);
          //Console.WriteLine(a.Device.AdvertisementRecords.Count);
        }
      };
      await adapter.StartScanningForDevicesAsync();

    }
    else
    {
      ScanButtonText = "Scan";
      ScanResults = "";
      scanning = false;

      adapter = null;
      DiscoveredPeripherals.Clear();
    }
  }

  public ICommand TransferScannedBLEItemCommand => new Command<BluetoothPeripheral>(TransferScannedBLEItemControl);
  public void TransferScannedBLEItemControl(BluetoothPeripheral p)
  {
    //Console.WriteLine($"You tapped on {p.Name}");

    BluetoothPeripheral a = new()
    {
      Name                = p.Name,
      DeviceName          = p.DeviceName,
      Id                  = p.Id,
      State               = p.State,
      Rssi                = p.Rssi,
      AdvertisementCount  = p.AdvertisementCount,
    };

    //need to see if peripheral in list
    bool found = false;
    foreach (BluetoothPeripheral q in BluetoothPeripherals)
    {
      if (a.Name == q.Name)
      {
        found = true;
        break;
      }
      //Console.WriteLine(q.Name);
    }

    if (!found) BluetoothPeripherals.Add(a);


  }


}
