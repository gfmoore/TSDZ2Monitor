using InTheHand.Bluetooth;
using TSDZ2Monitor.Classes;
using TSDZ2Monitor.Controls;


namespace TSDZ2Monitor.Pages;

public partial class BluetoothPage : ContentPage
{
	public BluetoothPage()
	{
		InitializeComponent();

		Console.WriteLine("Bluetooth here");

    getBLEPermission();
    static async void getBLEPermission()
    {
      PermissionStatus status = await Permissions.RequestAsync<BluetoothPermissions>();
      if (status != PermissionStatus.Granted)
      {
        status = await Permissions.RequestAsync<BluetoothPermissions>();
        if (status != PermissionStatus.Granted)
        {
          //well kill the app because it's no use
          return;
        }
      }
      Console.WriteLine("So is Bluetooth enabled?");
    }

  }

  //private void OnQuit(object sender, EventArgs e)
  //{
  //  Console.WriteLine($"Peripheral clicked {(Label)sender}");
  //}


}



