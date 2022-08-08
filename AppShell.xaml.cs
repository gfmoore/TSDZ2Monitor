namespace TSDZ2Monitor;

public partial class AppShell : Shell
{
  public AppShell()
  {
    InitializeComponent();

    Routing.RegisterRoute(nameof(Display2Page), typeof(Display2Page));
    Routing.RegisterRoute(nameof(Display3Page), typeof(Display3Page));
    Routing.RegisterRoute(nameof(Display4Page), typeof(Display4Page));
    Routing.RegisterRoute(nameof(Display5Page), typeof(Display5Page));
    Routing.RegisterRoute(nameof(Display6Page), typeof(Display6Page));

    Routing.RegisterRoute(nameof(BluetoothDetailPage), typeof(BluetoothDetailPage));
    Routing.RegisterRoute(nameof(TracksListPage), typeof(TracksListPage));
  }

}
