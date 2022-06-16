using TSDZ2Monitor.Classes;

namespace TSDZ2Monitor.Pages;

public partial class BluetoothPage : ContentPage
{


  public BluetoothPage()
  {
    InitializeComponent();

  }






  private async void ContentPage_Loaded(object sender, EventArgs e)
  {
    //do Bluetooth permissions
    Console.WriteLine("Let's request Bluetooth permissions");
    await CheckAndRequestBluetoothPermissionAsync();

    await BluetoothPage.SetupBluetoothAsync();



  }
  
  public async Task CheckAndRequestBluetoothPermissionAsync()
  {
    if (!await CheckBluetoothAccessAsync())
    {
      //bool blePermissionGranted = await App.Current.MainPage.DisplayAlert("Alert", "Allow use of bluetooth for scanning for your peripheral devices such as heart rate monitor etc?", "Allow", "Deny");
//Testing
bool blePermissionGranted = true;

      if (blePermissionGranted)
      {
        await RequestBluetoothAccessAsync();
      }
      else
      {
        Console.WriteLine("Can't run the app without granting Bluetooth permission!!");
        return;
      }
    }
  }

  public async Task<bool> CheckBluetoothAccessAsync()
  {
    try
    {
      Console.WriteLine("Check Bluetooth permission");
      var requestStatus = await Permissions.CheckStatusAsync<BluetoothPermissions>();
      return requestStatus == PermissionStatus.Granted;
    }
    catch (Exception e)
    {
      Console.WriteLine($"Oops on Check permission {e}");
      return false;
    }
  }

  public async Task<bool> RequestBluetoothAccessAsync()
  {
    try
    {
      Console.WriteLine("Request Bluetooth permission");
      var requestStatus = await Permissions.RequestAsync<BluetoothPermissions>();
      return requestStatus == PermissionStatus.Granted;
    }
    catch (Exception e)
    {
      Console.WriteLine($"Oops on Request permission {e}");
      return false;
    }
  }

  public static Task<bool> SetupBluetoothAsync()
  {
    Console.WriteLine("Setup Bluetooth scanning");
    var ble = CrossBluetoothLE.Current;

    //listen to see if bluetooth on or off
    var state = ble.State;
    ble.StateChanged += (s, e) =>
    {
      Console.WriteLine($"The bluetooth state changed to {e.NewState}");
    };
    return Task.FromResult(true);
  }

}
