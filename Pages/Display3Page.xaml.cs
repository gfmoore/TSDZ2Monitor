namespace TSDZ2Monitor.Pages;

public partial class Display3Page : ContentPage
{
	public Display3Page(Display3PageViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;
  }

}