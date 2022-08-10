namespace TSDZ2Monitor.Pages;

public partial class Display1Page : ContentPage
{
  public float[] speeds = {0.0f, 0.0f, 2.0f, 2.5f, 3.0f, 4.0f, 5.0f, 7.0f, 10.0f, 10.0f, 10.0f, 12.0f,
                      13.0f, 15.0f, 15.0f, 10.0f, 10.0f, 12.0f, 13.0f, 15.0f, 15.0f, 17.0f,
                      20.0f, 20.0f, 21.0f, 25.0f, 24.0f, 23.0f, 26.0f, 30.0f, 34.0f, 34.0f, 38.0f, 38.0f,
                      39.0f, 41.0f, 42.0f, 39.0f, 40.0f, 40.0f, 45.0f, 49.0f, 50.0f, 55.0f, 54.0f, 57.0f,
                      59.0f, 62.0f, 63.0f, 65.0f, 66.0f, 70.0f, 75.0f, 75.0f, 79.0f, 80.0f, 83.0f, 83.0f, 84.0f, 90.0f,
                      100.0f, 102.0f, 89.0f, 87.0f, 85.0f, 81.0f, 81.0f, 75.0f, 72.0f, 67.0f, 66.0f, 64.0f,
                      59.0f, 55.0f, 51.0f, 45.0f, 44.0f, 39.0f, 26.0f, 25.0f, 25.0f, 22.0f, 20.0f, 18.0f, 18.0f,
                      16.0f, 14.0f, 10.0f, 8.0f, 5.0f, 5.0f, 2.0f, 0.0f, 0.0f };

  private static readonly System.Timers.Timer timer = new(500);

  public Display1Page(Display1PageViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;

    timer.Elapsed += OnTimedEvent;
    timer.AutoReset = true;
  }

  private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
  {

    GraphicsArea.Invalidate();
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


  private void DoIt_Clicked(object sender, EventArgs e)
  {
    Debug.WriteLine("Hi G");

    //int i = 0;
    //while (true)
    //{
    //  System.Threading.Thread.Sleep(1000);
    //  i++;
    //  if (i == speeds.Length - 1) i = 0;
    //  GraphicsArea.Invalidate();

    //}

    //GraphicsArea.Invalidate();
    timer.Start();
  }
}