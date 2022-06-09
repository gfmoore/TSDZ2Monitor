using Android;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;

namespace TSDZ2Monitor.Pages;

public partial class BluetoothPage : ContentPage
{
	public BluetoothPage()
	{
		InitializeComponent();

		Console.WriteLine("Bluetooth here");
    var ble = CrossBluetoothLE.Current;
    var adapter = CrossBluetoothLE.Current.Adapter;
    var state = ble.State;

    getBLEPermission();
    //startScan();

    //see if bluetooth turned on or off
    ble.StateChanged += (s, e) =>
    {
      Console.WriteLine($"The bluetooth state changed to {e.NewState}");
    };

    adapter.DeviceDiscovered += (s, a) => Console.WriteLine(a.Device);
    
    //Need to get user to accept bluetooth permissions in Android 6.0+,v23 that is the Run-time Permissions check
    async void getBLEPermission()
    {
      bool blePermissionGranted = false;
      //now obtain current status - call the RequestPermissions method in Android SDK
      //PermissionStatus blePermissionGrantedx = await Permissions.CheckStatusAsync<Permissions.Battery>();
      //Console.WriteLine(blePermissionGrantedx);

      int sdk = (int)Build.VERSION.SdkInt;

      const int locationPermissionsRequestCode = 1000;
      var locationPermissions = new[]
      {
        Manifest.Permission.AccessCoarseLocation,
        Manifest.Permission.AccessFineLocation
      };

      // check if the app has permission to access coarse location
      var coarseLocationPermissionGranted =
          ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation);

      RequestPermissions(new string[] { Manifest.Permission.AccessCoarseLocation, 
                                        Manifest.Permission.BluetoothAdmin }, 1);





      if (!blePermissionGranted)
      {
        

        blePermissionGranted = await App.Current.MainPage.DisplayAlert("Alert", "Allow use of bluetooth for scanning for your peripheral devices such as heart rate monitor etc?", "Allow", "Deny");
        if (blePermissionGranted)
        {
          //set the permission on android

        }
        Console.WriteLine($"SDK version {sdk}");
        Console.WriteLine($"BLE permission granted: {blePermissionGranted}");

      }

    }

    async void startScan()
    {
      await adapter.StartScanningForDevicesAsync();
    }
  }



}