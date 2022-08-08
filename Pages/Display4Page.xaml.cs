namespace TSDZ2Monitor.Pages;

public partial class Display4Page : ContentPage
{
	public Display4Page(Display4PageViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;
  }

}