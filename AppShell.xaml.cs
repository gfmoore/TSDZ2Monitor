namespace TSDZ2Monitor;

public partial class AppShell : Shell
{
  public AppShell()
  {
    InitializeComponent();

    Routing.RegisterRoute(nameof(BluetoothDetailPage), typeof(BluetoothDetailPage));
    Routing.RegisterRoute(nameof(TracksListPage), typeof(TracksListPage));
  }

}
