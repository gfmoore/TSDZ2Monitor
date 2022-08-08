namespace TSDZ2Monitor.Pages;

public partial class Display2Page : ContentPage
{
	public Display2Page(Display2PageViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;
  }

}