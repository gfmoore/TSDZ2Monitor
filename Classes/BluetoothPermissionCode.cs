namespace TSDZ2Monitor.Classes;

public class BluetoothPermissionCode : Permissions.BasePermission
{
  // This method checks if current status of the permission.
  public override Task<PermissionStatus> CheckStatusAsync()
  {
    Console.WriteLine("***Bluetooth: CheckStatusAsync");
    throw new System.NotImplementedException();
  }

  // This method is optional and a PermissionException is often thrown if a permission is not declared.
  public override void EnsureDeclared()
  {
    Console.WriteLine("***Bluetooth: EnsureDeclared");
  }

  // Requests the user to accept or deny a permission.
  public override Task<PermissionStatus> RequestAsync()
  {
    Console.WriteLine("***Bluetooth: RequestAsync");
    throw new System.NotImplementedException();
  }

  // Indicates that the requestor should prompt the user as to why the app requires the permission, because the
  // user has previously denied this permission.
  public override bool ShouldShowRationale()
  {
    Console.WriteLine("***Bluetooth: ShouldShowRationale");
    throw new System.NotImplementedException();
  }
}
