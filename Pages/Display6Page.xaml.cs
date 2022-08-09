namespace TSDZ2Monitor.Pages;

public partial class Display6Page : ContentPage
{
	public Display6Page(Display6PageViewModel viewModel)
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
    //if (e.Direction == SwipeDirection.Left)
    //{
    //  var navigationParameter = new Dictionary<string, object>
    //  {
    //    { "TestData", "Test Data" }
    //  };
    //  await Shell.Current.GoToAsync(nameof(Display3Page), true, navigationParameter);
    //}
  }
}