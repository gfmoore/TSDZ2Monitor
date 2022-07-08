namespace TSDZ2Monitor.Pages;

public partial class DisplayPage : ContentPage
{
	public DisplayPage(DisplayPageViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;
  }
}