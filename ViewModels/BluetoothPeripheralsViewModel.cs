namespace TSDZ2Monitor.ViewModels;

public partial class BluetoothPeripheralsViewModel : ObservableObject
{
  private static Database database;
  private static string filename = "GM.db3";
  public static Database Database
  {
    get
    {
      if (database == null)
      {
        database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename));
        //database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename));
      }

      return database;
    }
  }



  bool scanning = false;

  [ObservableProperty]
  String scanButtonText = "Scan";

  [ObservableProperty]
  String scanResults = String.Empty;

  //create a list for remembered ble peripherals
  [ObservableProperty]
  public static ObservableCollection<BluetoothPeripheral> bluetoothPeripherals = new()
  {
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
  public void DeleteBLEItemControl(BluetoothPeripheral p)
  {
    //Console.WriteLine($"delete {btp.Name}");
    //need to find the actual item in the list otherwise changes are not updated in ui

    foreach (BluetoothPeripheral q in BluetoothPeripherals)
    {
      if (Equals(p, q))
      {
        if (!q.CancelBinIsVisible)
        {
          q.CancelBinIsVisible = true;
        }
        else
        {
          q.CancelBinIsVisible = false;
          BluetoothPeripherals.Remove(q);
        }
        break;
      }
    }




  }


  //remove peripheral
  public ICommand CancelDeleteBLEItemCommand => new Command<BluetoothPeripheral>(CancelDeleteBLEItemControl);
  public void CancelDeleteBLEItemControl(BluetoothPeripheral btp)
  {
    Console.WriteLine($"cancel delete {btp.Name}");
    btp.CancelBinIsVisible = false;
  }

  //show details
  public ICommand ShowBLEItemCommand => new Command<BluetoothPeripheral>(ShowBLEItemControl);
  public void ShowBLEItemControl(BluetoothPeripheral p)
  {
    Console.WriteLine($"You tapped on {p.Name}");
  }


  public ICommand ScanBLEPeripheralsCommand => new Command(ScanBLEPeripheralsControl);
  public async void ScanBLEPeripheralsControl()
  {
    var adapter = CrossBluetoothLE.Current.Adapter;
    adapter.ScanTimeout = 10000; //assume ms, so 10s
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
            Name = a.Device.Name,
            DeviceName = a.Device.NativeDevice.ToString(),
            Id = a.Device.Id.ToString(),
            State = a.Device.State.ToString(),
            Rssi = a.Device.Rssi,
            AdvertisementCount = a.Device.AdvertisementRecords.Count
          };

          //need to see if peripheral in list
          bool found = false;
          foreach (BluetoothPeripheral q in DiscoveredPeripherals)
          {
            if (p.Name == q.Name)
            {
              found = true;
              break;
            }
          }

          if (!found) DiscoveredPeripherals.Add(p);

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
      Name = p.Name,
      DeviceName = p.DeviceName,
      Id = p.Id,
      State = p.State,
      Rssi = p.Rssi,
      AdvertisementCount = p.AdvertisementCount,
      CancelBinIsVisible = false,
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


  [ObservableProperty]
  public static ObservableCollection<User> u = new();
  List<User> userlist = new();
  public ICommand DBStuffCommand => new Command(DBStuffControl);
  public async void DBStuffControl()
  {
    Console.WriteLine("Got here");
    //await Database.DropTableUsersAsync();
    //await Database.CreateTableUsersAsync();

    await Database.SaveUserAsync(new User
    {
      Username = "Jane"
    });

    userlist = await Database.GetUsersAsync();
    u.Clear();
    userlist.ForEach(x => u.Add(x));  //convert list to observable collection

    Console.WriteLine("Got here as well");
  }
}
