namespace TSDZ2Monitor.Classes;

public class BluetoothPermissions : Permissions.BasePlatformPermission
{
  public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
    new List<(string androidPermission, bool isRuntime)>
    {
        (global::Android.Manifest.Permission.AccessCoarseLocation, true),
        (global::Android.Manifest.Permission.AccessFineLocation, true),

        (global::Android.Manifest.Permission.Bluetooth, true),
        (global::Android.Manifest.Permission.BluetoothAdmin, true),
        (global::Android.Manifest.Permission.BluetoothScan, true),
        (global::Android.Manifest.Permission.BluetoothConnect, true),
        (global::Android.Manifest.Permission.BluetoothAdvertise, true)

    }.ToArray();
}
