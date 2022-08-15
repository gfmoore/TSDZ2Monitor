namespace TSDZ2Monitor.Pages;

public partial class Display2Page : ContentPage
{
	public Display2Page(Display2ViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;
  }

  public async void OnSwiped(object Sender, SwipedEventArgs e)
  {
    if (e.Direction == SwipeDirection.Right)
    {
      await Shell.Current.GoToAsync("..");
    }
    if (e.Direction == SwipeDirection.Left)
    {
      var navigationParameter = new Dictionary<string, object>
      {
        { "TestData", "Test Data" }
      };
      await Shell.Current.GoToAsync(nameof(Display3Page), true, navigationParameter);
    }
  }

}