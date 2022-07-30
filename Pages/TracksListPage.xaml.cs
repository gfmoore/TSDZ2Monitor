namespace TSDZ2Monitor.Pages;

public partial class TracksListPage : ContentPage
{
	public TracksListPage(TracksListViewModel viewModel)
	{
		InitializeComponent();
    BindingContext = viewModel;
  }
}