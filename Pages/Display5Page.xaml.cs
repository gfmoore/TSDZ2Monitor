namespace TSDZ2Monitor.Pages;

public partial class Display5Page : ContentPage
{
	public Display5Page(Display3PageViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;
  }

}