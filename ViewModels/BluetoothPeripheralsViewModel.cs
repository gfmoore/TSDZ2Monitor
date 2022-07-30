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
    cts1 = new();
    cts2 = new();
    cts3 = new();
    //cts4 = new();
    //ct = cancellationTokenSource.Token;

    //Add the event handler
    adapter.DeviceDiscovered += AdapterDeviceDiscovered;

    //Add the device disconnected event
    adapter.DeviceDisconnected += AdapterDeviceDisconnected;

    //Get what's in the sqlite database
    LoadExistingBluetoothPeripherals();

  }

  //set up a global BluetoothData object
  public BluetoothData btd = new();

  IBluetoothLE ble;
  IAdapter adapter;

  Plugin.BLE.Abstractions.ConnectParameters cp = new(true, true);
  CancellationTokenSource cts1;
  CancellationTokenSource cts2;
  CancellationTokenSource cts3;
  //CancellationTokenSource cts4;

  enum ScanStatus { Scanning, Halted, Stopped};
  ScanStatus scanning = ScanStatus.Stopped;

  int scanCounter = 10;  //countdown
  private static readonly System.Timers.Timer timer = new(1000); //for scanning time 1 second, but do 10x

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

    //set the basic color to Yellow
    foreach (BluetoothPeripheral btp in BluetoothPeripherals)
    {
      btp.ItemColor = "Yellow";
    }
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

    //Debug.WriteLine($"You tapped on {SelectedItem.Name}");

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

  IDevice deviceHRM, deviceSPD, deviceCAD; //, deviceXXX;
  System.Collections.Generic.IReadOnlyList<Plugin.BLE.Abstractions.Contracts.IService> servicesHRM, servicesSPD, servicesCAD; //, servicesXXX;

  int         HRM;
  double      HRR;

  int         SPDWheelRevolutions, PreviousSPDWheelRevolutions, SPDWheelRevolutionsDifference;
  double      SPDWheelEventTime, PreviousSPDWheelEventTime, SPDWheelEventTimeDifference;
  double      WheelRPM;

  int         CADCrankRevolutions, PreviousCADCrankRevolutions, CADCrankRevolutionsDifference;
  double      CADCrankEventTime, PreviousCADCrankEventTime, CADCrankEventTimeDifference;
  double      Cadence;
    
  //int         XXX;

  [RelayCommand]
  public async void ConnectToPeripherals()
  {
    Debug.WriteLine("Trying to connect to devices...");


    foreach (BluetoothPeripheral btp in BluetoothPeripherals)
    {
      Debug.WriteLine($"{btp.Name}");
      if (btp.Name[..3] == "HRM")
      {
        Guid guid = new(btp.DeviceId);
        try
        {
          btp.ItemColor = "Orange";
          deviceHRM = await adapter.ConnectToKnownDeviceAsync(guid, cp, cts1.Token);
          btp.ItemColor = "LightGreen";

          //now have to get services for this device
          try
          {
            servicesHRM = await deviceHRM.GetServicesAsync();

            foreach (var serviceHRM in servicesHRM)
            {
              if (serviceHRM.Name == "Heart Rate")
              {
                //now get characteristics for this service
                try
                {
                  var characteristicsHRM = await serviceHRM.GetCharacteristicsAsync();

                  //now get the guid for Heart Rate Measurement
                  foreach (var characteristicHRM in characteristicsHRM)
                  {
                    //Debug.WriteLine(characteristicHRM.Name);
                    if (characteristicHRM.Name == "Heart Rate Measurement")
                    {
                      characteristicHRM.ValueUpdated += (o, args) =>
                      {
                        var bytes = args.Characteristic.Value;

                        if (bytes.Length == 2)
                        {
                          //Debug.WriteLine($" HRM: {bytes[0]} {bytes[1]}");

                          HRM = bytes[1];
                          HRR = 0;
                        }
                        if (bytes.Length == 4)  //also get HRM and HRR
                        {
                          //Debug.WriteLine($" R-R: {bytes[0]} {bytes[1]} {bytes[2]} {bytes[3]}");

                          HRM = bytes[1];
                          HRR = ((double)((bytes[3] * 256) + bytes[2])) / 1024.0;
                        }

                        btd.HRM = HRM;
                        btd.HRR = HRR;

                        MessagingCenter.Send(new MessagingMarker(), "BTDataUpdate", btd);
                      };

                      //call the characteristic updates handler
                      await characteristicHRM.StartUpdatesAsync();
                    }

                  }
                }
                catch (Exception e) { Debug.WriteLine($"TSDZ2: Error getting HRM characteristics {e.Message}"); }
              }
            }
          }
          catch (Exception e) { Debug.WriteLine($"TSDZ2: Error getting HRM services {e.Message}"); }
        }
        catch (Exception e) { Debug.WriteLine($"TSDZ2: Error connecting to HRM {e.Message}"); }
        //End of HRM
      }

      if (btp.Name[..3] == "SPD")
      {
        Guid guid = new(btp.DeviceId);
        PreviousSPDWheelRevolutions = 0; //the first calc will be incorrect
        PreviousSPDWheelEventTime = 0;  
        try
        {
          btp.ItemColor = "Orange";
          deviceSPD = await adapter.ConnectToKnownDeviceAsync(guid, cp, cts2.Token);
          btp.ItemColor = "LightGreen";

          //now have to get services for this device
          try
          {
            servicesSPD = await deviceSPD.GetServicesAsync();

            foreach (var serviceSPD in servicesSPD)
            {
              Debug.WriteLine(serviceSPD.Name);
              if (serviceSPD.Name == "Cycling Speed and Cadence")
              {
                //now get characteristics for this service
                try
                {
                  var characteristicsSPD = await serviceSPD.GetCharacteristicsAsync();

                  //now get the guid for Heart Rate Measurement
                  foreach (var characteristicSPD in characteristicsSPD)
                  {
                    if (characteristicSPD.Name == "CSC Measurement")
                    {
                      characteristicSPD.ValueUpdated += (o, args) =>
                      {
                        var bytes = args.Characteristic.Value;

                        if (bytes.Length == 7)
                        {
                          SPDWheelRevolutions = ((bytes[4] * 16777216) + (bytes[3] * 65536) + (bytes[2] * 256) + bytes[1]);
                          SPDWheelEventTime = ((double)((bytes[6] * 256) + bytes[5])) / 1024.0;

                          SPDWheelRevolutionsDifference = SPDWheelRevolutions - PreviousSPDWheelRevolutions;
                          SPDWheelEventTimeDifference = SPDWheelEventTime - PreviousSPDWheelEventTime;

                          if (SPDWheelEventTimeDifference != 0)  //otherwise divide by 0
                          {
                            WheelRPM = 60.0 * ((double)SPDWheelRevolutionsDifference) / SPDWheelEventTimeDifference;
 
                            PreviousSPDWheelRevolutions = SPDWheelRevolutions;
                            PreviousSPDWheelEventTime = SPDWheelEventTime;
                          }

                          btd.SPDWheelRevolutions = SPDWheelRevolutions;
                          btd.SPDWheelEventTime = SPDWheelEventTime;
                          btd.WheelRPM = WheelRPM;

                          MessagingCenter.Send(new MessagingMarker(), "BTDataUpdate", btd);
                        }
                      };

                      //call the characteristic updates handler
                      await characteristicSPD.StartUpdatesAsync();
                    }
                  }
                }
                catch (Exception e) { Debug.WriteLine($"TSDZ2: Error getting SPD characteristics {e.Message}"); }
              }
            }
          }
          catch (Exception e) { Debug.WriteLine($"TSDZ2: Error getting SPD services {e.Message}"); }
        }
        catch (Exception e) { Debug.WriteLine($"TSDZ2: Error connecting to SPD {e.Message}"); }
        //End of SPD
      }

      if (btp.Name[..3] == "CAD")
      {
        Guid guid = new(btp.DeviceId);
        PreviousCADCrankRevolutions = 0; //the first calc will be incorrect
        PreviousCADCrankEventTime = 0;  //Stop divide by 0
        try
        {
          btp.ItemColor = "Orange";
          deviceCAD = await adapter.ConnectToKnownDeviceAsync(guid, cp, cts3.Token);
          btp.ItemColor = "LightGreen";

          //now have to get services for this device
          try
          {
            servicesCAD = await deviceCAD.GetServicesAsync();

            foreach (var serviceCAD in servicesCAD)
            {
              Debug.WriteLine(serviceCAD.Name);
              if (serviceCAD.Name == "Cycling Speed and Cadence")
              {
                //now get characteristics for this service
                try
                {
                  var characteristicsCAD = await serviceCAD.GetCharacteristicsAsync();

                  //now get the guid for Heart Rate Measurement
                  foreach (var characteristicCAD in characteristicsCAD)
                  {
                    if (characteristicCAD.Name == "CSC Measurement")
                    {
                      characteristicCAD.ValueUpdated += (o, args) =>
                      {
                        var bytes = args.Characteristic.Value;

                        if (bytes.Length == 5)
                        {
                          CADCrankRevolutions = ((bytes[2] * 256) + bytes[1]);
                          CADCrankEventTime = ((double)((bytes[4] * 256) + bytes[3])) / 1024.0;

                          CADCrankRevolutionsDifference = CADCrankRevolutions - PreviousCADCrankRevolutions;
                          CADCrankEventTimeDifference = CADCrankEventTime - PreviousCADCrankEventTime;

                          if (CADCrankEventTimeDifference != 0)
                          {
                            Cadence = 60.0 * ((double)CADCrankRevolutionsDifference) / CADCrankEventTimeDifference;
 
                            PreviousCADCrankRevolutions = CADCrankRevolutions;
                            PreviousCADCrankEventTime = CADCrankEventTime;
                          }

                          btd.CADCrankRevolutions = CADCrankRevolutions;
                          btd.CADCrankEventTime = CADCrankEventTime / 1024.0;
                          btd.Cadence = Cadence;

                          MessagingCenter.Send(new MessagingMarker(), "BTDataUpdate", btd);
                        }
                      };

                      //call the characteristic updates handler
                      await characteristicCAD.StartUpdatesAsync();
                    }
                  }
                }
                catch (Exception e) { Debug.WriteLine($"TSDZ2: Error getting CAD characteristics {e.Message}"); }
              }
            }
          }
          catch (Exception e) { Debug.WriteLine($"TSDZ2: Error getting CAD services {e.Message}"); }
        }
        catch (Exception e) { Debug.WriteLine($"TSDZ2: Error connecting to CAD {e.Message}"); }
        //End of CAD
      }

      if (btp.Name[..3] == "XXX")
      {
        //Guid guid = new(btp.DeviceId);
        //try
        //{
        //  deviceXXX = await adapter.ConnectToKnownDeviceAsync(guid, cp, cts4.Token);
        //  Debug.WriteLine("Device CAD connected ");

        //  //now have to get services for this device
        //  try
        //  {
        //    servicesXXX = await deviceXXX.GetServicesAsync();
        //    Debug.WriteLine("Services for XXX");

        //    foreach (var serviceXXX in servicesXXX)
        //    {
        //      Debug.WriteLine(serviceXXX.Name);
        //      if (serviceXXX.Name == "XXX")
        //      {
        //        //now get characteristics for this service
        //        try
        //        {
        //          var characteristicsXXX = await serviceXXX.GetCharacteristicsAsync();

        //          //now get the guid for Heart Rate Measurement
        //          foreach (var characteristicXXX in characteristicsXXX)
        //          {
        //            Debug.WriteLine(characteristicXXX.Name);
        //            if (characteristicXXX.Name == "XXX")
        //            {
        //              characteristicXXX.ValueUpdated += (o, args) =>
        //              {
        //                var bytes = args.Characteristic.Value;
        //                Debug.WriteLine(bytes);
        //              };

        //              //call the characteristic updates handler
        //              await characteristicXXX.StartUpdatesAsync();
        //            }
        //          }
        //        }
        //        catch (Exception e) { Debug.WriteLine($"TSDZ2: Error getting XXX characteristics {e.Message}"); }
        //      }
        //    }
        //  }
        //  catch (Exception e) { Debug.WriteLine($"TSDZ2: Error getting XXX services {e.Message}"); }
        //}
        //catch (Exception e) { Debug.WriteLine($"TSDZ2: Error connecting to XXX {e.Message}"); }
        //End of XXX

      }
    }
  }


  [RelayCommand]
  public void DisconnectToPeripherals()
  {
    Debug.WriteLine("Disconnect...");
    cts1.Cancel();
    cts2.Cancel();
    cts3.Cancel();
    //cts4.Cancel();
    //set the basic color to Yellow
    foreach (BluetoothPeripheral btp in BluetoothPeripherals)
    {
      btp.ItemColor = "Yellow";
    }
  }

  private void AdapterDeviceConnected(Object s, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs a)
  {
    Debug.WriteLine($"TSDZ2: Device connected: {a.Device.Name}");
    //Scan through BluetoothPeripherals and set colour to Green
    foreach (BluetoothPeripheral btp in BluetoothPeripherals)
    {
      if (btp.Name == a.Device.Name)
      {
        btp.ItemColor = "LightGreen";
      }
    }
  }

  //doesn't seem to work for Android!!!
  private void AdapterDeviceDisconnected(Object s, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs a)
  {
    Debug.WriteLine($"TSDZ2: Device disconnected: {a.Device.Name}");
    //Scan through BluetoothPeripherals and set colour to Yellow
    foreach(BluetoothPeripheral btp in BluetoothPeripherals)
    {
      if (btp.Name == a.Device.Name )
      {
        btp.ItemColor = "Yellow";
      }
    }
  }
}

