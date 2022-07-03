namespace TSDZ2Monitor.ViewModels;

public partial class BluetoothPeripheralsViewModel : ObservableObject
{
  public BluetoothPeripheralsViewModel()
  {
    //timer to limit scan time and then reset the scan button
    //do a 10 second countdown timer each second for display on scan button
    timer.Elapsed += OnTimedEvent;  
    timer.AutoReset = true;

    //Setup blutooth adapter
    ble = CrossBluetoothLE.Current;
    adapter = CrossBluetoothLE.Current.Adapter;
    //adapter.ScanTimeout = 10000; //assume ms, so 10s

    //Add the event handler
    adapter.DeviceDiscovered += AdapterDeviceDiscovered;

    //Get what's in the sqlite database
    LoadExistingBluetoothPeripherals();
  }

  IBluetoothLE ble;
  IAdapter adapter;

  bool scanning = false;
  int scanCounter = 10;  //countdown

  private static readonly System.Timers.Timer timer = new(1000); //1 second, but do 10x

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


  //Load saved peripherals
  private async void LoadExistingBluetoothPeripherals()
  {
    List<BluetoothPeripheral> l = await App.Database.GetBluetoothPeripheralsAsync();
    BluetoothPeripherals = new ObservableCollection<BluetoothPeripheral>(l);
  }

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
  public async static void ShowBLEItem(BluetoothPeripheral p)
  {
    Debug.WriteLine($"You tapped on {p.Name}");

    //Show details
    var navigationParameter = new Dictionary<string, object>
    {
        { "BluetoothPeripheral", p }
    };
    await Shell.Current.GoToAsync(nameof(BluetoothDetailPage), true, navigationParameter);

  }


  [RelayCommand]
  public async void ScanBLEPeripherals()
  {
    //start a timer
    Debug.WriteLine("Timer started");
    timer.Start();

    if (!scanning)
    {
      ScanButtonText = $"Stop scan {scanCounter}";
      ScanResults = "Scanning for BLE peripherals...";
      scanning = true;

      await adapter.StartScanningForDevicesAsync();
    }
    else
    {
      ClearScanning();
    }
  }

  //Event handler for adapter.DeviceDiscovered
  private void AdapterDeviceDiscovered(Object s, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs a)
  {
    Debug.WriteLine(a.Device.Name);
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
  }

  private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
  {
    scanCounter -= 1;
    ScanButtonText = $"Stop scan {scanCounter}";
    if (scanCounter == 0)
    {
      ClearScanning();
      scanCounter = 10;
    }

  }

  private void ClearScanning()
  {
    timer.Stop();
    timer.Close();
    Debug.WriteLine("Timer stopped");

    ScanButtonText = "Scan";
    ScanResults = "";
    scanning = false;

    DiscoveredPeripherals.Clear();

    //remove the event as it gets added again in scanning function
    //TODO is there a way I can just add the event once and forget
    //adapter.DeviceDiscovered -= Adapter_DeviceDiscovered;
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

