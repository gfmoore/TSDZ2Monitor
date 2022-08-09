namespace TSDZ2Monitor.Pages;

public partial class Display1Page : ContentPage
{
	public Display1Page(Display1PageViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;
  }

	public async void OnSwiped(object Sender, SwipedEventArgs e)
	{
		Debug.WriteLine($"Swiped {e.Direction}");
		if (e.Direction == SwipeDirection.Left)
		{
      var navigationParameter = new Dictionary<string, object>
      {
        { "TestData", "Test Data" }
      };
      await Shell.Current.GoToAsync(nameof(Display2Page), true, navigationParameter);

    }
  }
}