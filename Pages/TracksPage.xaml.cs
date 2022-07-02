namespace TSDZ2Monitor.Pages;

public partial class TracksPage : ContentPage
{
	public TracksPage(TracksViewModel viewModel)
	{
		InitializeComponent();
    BindingContext = viewModel;
  }
}