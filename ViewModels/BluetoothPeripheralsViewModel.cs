using Plugin.BLE.Abstractions.Exceptions;
using System.Threading;
using System;

namespace TSDZ2Monitor.ViewModels;

public partial class BluetoothPeripheralsViewModel : ObservableObject
{
  public BluetoothPeripheralsViewModel()
  {
    //timer to limit scan time and then reset the scan button
    //do a 10 second countdown timer each second for display on scan button
    timer.Elapsed += OnTimedEvent;  
    timer.AutoReset = true;
    scanning = ScanStatus.Stopped;

    //Setup blutooth adapter
    ble = CrossBluetoothLE.Current;
    adapter = CrossBluetoothLE.Current.Adapter;
    //adapter.ScanTimeout = 10000; //assume ms, so 10s
    //adapter.ScanMode = ScanMode.Balanced;
    cts = new();
    //ct = cancellationTokenSource.Token;

    //Add the event handler
    adapter.DeviceDiscovered += AdapterDeviceDiscovered;

    //Add the device disconnected event
    adapter.DeviceDisconnected += AdapterDeviceDisconnected;


    //Get what's in the sqlite database
    LoadExistingBluetoothPeripherals();
  }

  IBluetoothLE ble;
  IAdapter adapter;


  Plugin.BLE.Abstractions.ConnectParameters cp = new(true, true);
  CancellationTokenSource cts;
  CancellationToken ct;


  enum ScanStatus { Scanning, Halted, Stopped};
  ScanStatus scanning = ScanStatus.Stopped;

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

  [ObservableProperty]
  private BluetoothPeripheral selectedItem;

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

  [RelayCommand]
  public async void SelectionChanged()
  {
    if (SelectedItem == null) return;

    Debug.WriteLine($"You tapped on {SelectedItem.Name}");

    //Show details
    var navigationParameter = new Dictionary<string, object>
    {
        { "BluetoothPeripheral", SelectedItem }
    };
    await Shell.Current.GoToAsync(nameof(BluetoothDetailPage), true, navigationParameter);

    //clear highlight
    SelectedItem = null;
  }

  [RelayCommand]
  public async void ScanBLEPeripherals()
  {

    if (scanning == ScanStatus.Stopped)  //start scan
    {
      //start a timer
      Debug.WriteLine("Timer started");
      timer.Start();

      ScanButtonText = $"Stop scan {scanCounter}";
      ScanResults = "Scanning for BLE peripherals...";
      scanning = ScanStatus.Scanning;

      await adapter.StartScanningForDevicesAsync();
    }
    else if (scanning == ScanStatus.Scanning)  //halt, but leave items visible
    {
      timer.Stop();
      timer.Close();
      Debug.WriteLine("Timer stopped");

      ScanButtonText = "Scan halted";
      ScanResults = "";
      
      scanning = ScanStatus.Halted;

    }
    else if (scanning == ScanStatus.Halted) //stop scan and clear 
    {
      ScanButtonText = "Scan";
      ScanResults = "";
      scanning = ScanStatus.Stopped;
      
      DiscoveredPeripherals.Clear();
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
      timer.Stop();
      timer.Close();
      Debug.WriteLine("Timer stopped");

      ScanButtonText = "Scan halted";
      scanning = ScanStatus.Halted;
      
      scanCounter = 10;
    }

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
  public async void ConnectToPeripherals()
  {
    Debug.WriteLine("Trying to connect...");
    foreach (BluetoothPeripheral btp in BluetoothPeripherals)
    {
      Guid guid = new(btp.DeviceId);
      Debug.WriteLine($"{btp.Name}");

      try
      {
        var dvc = await adapter.ConnectToKnownDeviceAsync(guid, cp, cts.Token);
        Debug.WriteLine("Connected");

        var services = await dvc.GetServicesAsync();

        foreach (var service in services)
        {
          Debug.WriteLine($"{service.Name} {service.Device} {service.Id}");
          var characteristics = await service.GetCharacteristicsAsync();

          foreach (var characteristic in characteristics)
          {
            Debug.WriteLine($" ---> {characteristic.Name} {characteristic.Id}");  // {characteristic.Uuid}");



          }
        }
      }
      catch (DeviceConnectionException e)
      {
        Debug.WriteLine($"GM: Oops connection error {e.Message}");
      }
    }
  }


  [RelayCommand]
  public async void ReadCharacteristic()
  {
    Debug.WriteLine("Read Byte...");
    //Heart rate
    //Guid guid = new(BluetoothPeripherals[0].DeviceId);
    //var dvc = await adapter.ConnectToKnownDeviceAsync(guid, cp, cts.Token);
    //var service = await dvc.GetServiceAsync(Guid.Parse("0000180d-0000-1000-8000-00805f9b34fb"));
    //var characteristic = await service.GetCharacteristicAsync(Guid.Parse("00002a37-0000-1000-8000-00805f9b34fb"));    Guid guid = new(BluetoothPeripherals[0].DeviceId);

    //Speed and cadence
    Guid guid = new(BluetoothPeripherals[2].DeviceId);
    var dvc = await adapter.ConnectToKnownDeviceAsync(guid, cp, cts.Token);
    var service = await dvc.GetServiceAsync(Guid.Parse("00001816-0000-1000-8000-00805f9b34fb"));
    var characteristic = await service.GetCharacteristicAsync(Guid.Parse("00002a5b-0000-1000-8000-00805f9b34fb"));

    //add event handler for characteristic
    characteristic.ValueUpdated += (o, args) =>
    {
      var bytes = args.Characteristic.Value;
      //Debug.WriteLine($"{bytes.Length}");
      if (bytes.Length == 7) Debug.WriteLine($" SPD: {bytes[0]} {bytes[1]} {bytes[2]} {bytes[3]} {bytes[4]} {bytes[5]} {bytes[6]}");
      if (bytes.Length == 5) Debug.WriteLine($" CDC: {bytes[0]} {bytes[1]} {bytes[2]} {bytes[3]} {bytes[4]}");
    };
    //call the characteristic updates handler
    await characteristic.StartUpdatesAsync();
  }


  [RelayCommand]
  public void DisconnectToPeripherals()
  {
    Debug.WriteLine("Disconnect...");
    cts.Cancel();
  }

  //doesn't seem to work for Android!!!
  private void AdapterDeviceDisconnected(Object s, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs a)
  {
    Debug.WriteLine("Device disconnected");
  }
}

