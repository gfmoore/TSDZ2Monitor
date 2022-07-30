namespace TSDZ2Monitor.Pages;

public partial class BluetoothPage : ContentPage
{
  public BluetoothPage(BluetoothPeripheralsViewModel viewModel)
  {
    InitializeComponent();
    BindingContext = viewModel;
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();

    //now do stuff like set up the database
    Debug.WriteLine("Bluetooth Page appearing");
  }


  private async void ContentPage_Loaded(object sender, EventArgs e)
  {
    //do Bluetooth permissions
    Debug.WriteLine("Let's request Bluetooth permissions");
    await BluetoothPage.CheckAndRequestBluetoothPermissionAsync();

    await BluetoothPage.SetupBluetoothAsync();

  }
  
  public static async Task CheckAndRequestBluetoothPermissionAsync()
  {
    if (!await BluetoothPage.CheckBluetoothAccessAsync())
    {
      //bool blePermissionGranted = await App.Current.MainPage.DisplayAlert("Alert", "Allow use of bluetooth for scanning for your peripheral devices such as heart rate monitor etc?", "Allow", "Deny");

//TODO Remove Testing

bool blePermissionGranted = true;

      if (blePermissionGranted)
      {
        await BluetoothPage.RequestBluetoothAccessAsync();
      }
      else
      {
        Debug.WriteLine("Can't run the app without granting Bluetooth permission!!");
        return;
      }
    }
  }

  public static async Task<bool> CheckBluetoothAccessAsync()
  {
    try
    {
      Debug.WriteLine("Check Bluetooth permission");
      var requestStatus = await Permissions.CheckStatusAsync<BluetoothPermissions>();
      return requestStatus == PermissionStatus.Granted;
    }
    catch (Exception e)
    {
      Debug.WriteLine($"Oops on Check permission {e}");
      return false;
    }
  }

  public static async Task<bool> RequestBluetoothAccessAsync()
  {
    try
    {
      Debug.WriteLine("Request Bluetooth permission");
      var requestStatus = await Permissions.RequestAsync<BluetoothPermissions>();
      return requestStatus == PermissionStatus.Granted;
    }
    catch (Exception e)
    {
      Debug.WriteLine($"Oops on Request permission {e}");
      return false;
    }
  }

  public static Task<bool> SetupBluetoothAsync()
  {
    Debug.WriteLine("Setup Bluetooth scanning");
    var ble = CrossBluetoothLE.Current;
    var adapter = CrossBluetoothLE.Current.Adapter;

    //listen to see if bluetooth on or off
    var state = ble.State;
    ble.StateChanged += (s, e) =>
    {
      Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
    };
    return Task.FromResult(true);
  }

}
