namespace TSDZ2Monitor.Pages;

public partial class BluetoothDetailPage : ContentPage
{
	public BluetoothDetailPage(BluetoothPeripheralsDetailViewModel viewModel)
	{
		InitializeComponent();
    BindingContext = viewModel;
  }
}