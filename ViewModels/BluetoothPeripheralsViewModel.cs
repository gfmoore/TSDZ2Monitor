namespace TSDZ2Monitor.ViewModels;

public partial class BluetoothPeripheralsViewModel : ObservableObject
{
  public BluetoothPeripheralsViewModel()
  {
    //timer to limit scan time and then reset the scan button
    timer.Elapsed += OnTimedEvent;  
    timer.AutoReset = false;

    //Get what's in the database
    LoadExistingBluetoothPeripherals();
  }

  private static readonly System.Timers.Timer timer = new(10000);

  private async void LoadExistingBluetoothPeripherals()
  {
    List<BluetoothPeripheral> l = await App.Database.GetBluetoothPeripheralsAsync();
    BluetoothPeripherals = new ObservableCollection<BluetoothPeripheral>(l);
  }

  bool scanning = false;

  [ObservableProperty]
  String scanButtonText = "Scan";

  [ObservableProperty]
  String scanResults = String.Empty;

  //create a list for remembered ble peripherals
  [ObservableProperty]
  private ObservableCollection<BluetoothPeripheral> bluetoothPeripherals = new();

  //create a list for discovered ble peripherals
  [ObservableProperty]
  private ObservableCollection<BluetoothPeripheral> discoveredPeripherals = new();

  //remove peripheral
  [RelayCommand]
  public async void DeleteBLEItem(BluetoothPeripheral p)
  {
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
          await App.Database.DeleteBluetoothPeripheralAsync(q);
        }
        break;
      }
    }
  }

  //remove peripheral
  [RelayCommand]
  public static void CancelDeleteBLEItem(BluetoothPeripheral btp)
  {
    btp.CancelBinIsVisible = false;
  }

  //show details
  [RelayCommand]
  public static void ShowBLEItem(BluetoothPeripheral p)
  {
    Debug.WriteLine($"You tapped on {p.Name}");
    //TODO show details
  }


  [RelayCommand]
  public async void ScanBLEPeripherals()
  {
    //start a timer
    Debug.WriteLine("Timer started");
    timer.Start();

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
            DeviceId = a.Device.Id.ToString(),
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
      timer.Stop();
      timer.Close();

      ScanButtonText = "Scan";
      ScanResults = "";
      scanning = false;

      adapter = null;
      DiscoveredPeripherals.Clear();
    }
  }
  
  private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
  {
    // Code to be executed at the end of Timer 
    Debug.WriteLine("Timer ending 10 second count");
    timer.Stop();
    timer.Close();

    ScanButtonText = "Scan";
    ScanResults = "";
    scanning = false;

    //adapter = null;
    DiscoveredPeripherals.Clear();
  }

  [RelayCommand]
  public void TransferScannedBLEItem(BluetoothPeripheral p)
  {
    //need to see if peripheral in list of stored/displayed peripherals
    bool found = false;
    foreach (BluetoothPeripheral q in BluetoothPeripherals)
    {
      if (q.Name == p.Name)
      {
        found = true;
        break;
      }
    }

    if (!found)
    {
      BluetoothPeripherals.Add(p);
      App.Database.InsertBluetoothPeripheralAsync(p);
    }
  }


  [RelayCommand]
  public static void ConnectToPeripherals()
  {
    Debug.WriteLine("Trying to connect...");
    //TODO do the connections
  }

}

