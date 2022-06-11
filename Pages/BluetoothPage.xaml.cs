namespace TSDZ2Monitor.Pages;

public partial class BluetoothPage : ContentPage
{
  public BluetoothPage()
  {
    InitializeComponent();

    Console.WriteLine("Bluetooth here");

    var status = Task.Run(() => BluetoothPage.CheckBluetoothAccess() );

    Task.Run(() => BluetoothPage.RequestBluetoothAccess() );

    Task.Run(() => BluetoothPage.CheckLocationAccess() );

    RequestLocationPermission();
    static async void RequestLocationPermission()
    {
      PermissionStatus requestStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
    }
    //Task.Run(() => BluetoothPage.RequestLocationAccess() ); //can only be run in main thread??

  }

  public static async Task<bool> CheckBluetoothAccess()
  {
    try
    {
      var checkStatus = await Permissions.CheckStatusAsync<BluetoothPermissions>();
      return checkStatus == PermissionStatus.Granted;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Oops  {ex}");
      return false;
    }
  }

  public static async Task<bool> RequestBluetoothAccess()
  {
    try
    {
      var requestStatus = await Permissions.RequestAsync<BluetoothPermissions>();
      return requestStatus == PermissionStatus.Granted;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Oops  {ex}");
      return false;
    }
  }

  public static async Task<bool> CheckLocationAccess()
  {
    try
    {
      PermissionStatus checkStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
      return checkStatus == PermissionStatus.Granted;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Oops  {ex}");
      return false;
    }
  }
  //public static async Task<bool> RequestLocationAccess()
  //{
  //  try
  //  {
  //    PermissionStatus requestStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
  //    return requestStatus == PermissionStatus.Granted;
  //  }
  //  catch (Exception ex)
  //  {
  //    Console.WriteLine($"Oops  {ex}");
  //    return false;
  //  }
  //}

}




