using System.Collections.ObjectModel;
using System.Diagnostics;
using TSDZ2Monitor.Classes;

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

  //remove peripheral
  public ICommand DeleteBLEItemCommand => new Command<BluetoothPeripheral>(DeleteBLEItemControl);
  public void DeleteBLEItemControl(BluetoothPeripheral btp)
  {
    Console.WriteLine($"delete {btp.Name}");
    BluetoothPeripherals.Remove(btp);
  }
  
  //show details
  public ICommand ShowBLEItemCommand => new Command<BluetoothPeripheral>(BluetoothPeripheralsViewModel.ShowBLEItemControl);
  public static void ShowBLEItemControl(BluetoothPeripheral btp)
  {
    Console.WriteLine($"You tapped on {btp.Name}");
  }



  [ObservableProperty]
  String scanButtonText = "Scan";

  [ObservableProperty]
  String scanResults = String.Empty;

  bool  scanning = false;

  //create a list for found ble peripherals
  [ObservableProperty]
  ObservableUniqueCollection<BluetoothScannedPeripheral> scannedPeripherals = new();


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
        BluetoothScannedPeripheral p = new();
        p.Name = a.Device.Name;

        if (p.Name != null || p.Name != String.Empty)
        {
          scannedPeripherals.Add(p);
          Console.WriteLine($"Bluetooth peripheral found: {p.Name}");
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
      scannedPeripherals.Clear();
    }
  }

  public ICommand TransferScannedBLEItemCommand => new Command<BluetoothScannedPeripheral>(BluetoothPeripheralsViewModel.TransferScannedBLEItemControl);
  public static void TransferScannedBLEItemControl(BluetoothScannedPeripheral btp)
  {
    Console.WriteLine($"You tapped on {btp.Name}");
  }


}
