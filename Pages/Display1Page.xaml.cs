using TSDZ2Monitor.Classes;

namespace TSDZ2Monitor.Pages;

public partial class Display1Page : ContentPage
{
  public bool runSpeedo = false;

  public bool showTripTime = false;
  public string tripTimeStatus = "Stopped";

  public TimeSpan tripTime = TimeSpan.Zero;
  public DateTime tripStartTime;

  public float[] speeds = {0.0f, 0.0f, 2.0f, 2.5f, 3.0f, 4.0f, 5.0f, 7.0f, 10.0f, 10.0f, 10.0f, 12.0f,
                      13.0f, 15.0f, 15.0f, 10.0f, 10.0f, 12.0f, 13.0f, 15.0f, 15.0f, 17.0f,
                      19.0f, 20.0f, 21.0f, 25.0f, 24.0f, 23.0f, 26.0f, 30.0f, 34.0f, 34.0f, 38.0f, 38.0f,
                      39.0f, 41.0f, 42.0f, 39.0f, 40.0f, 40.0f, 45.0f, 49.0f, 50.0f, 55.0f, 54.0f, 57.0f,
                      59.0f, 62.0f, 63.0f, 65.0f, 66.0f, 70.0f, 75.0f, 75.0f, 79.0f, 80.0f, 83.0f, 83.0f, 84.0f, 90.0f,
                      100.0f, 102.0f, 89.0f, 87.0f, 85.0f, 81.0f, 81.0f, 75.0f, 72.0f, 67.0f, 66.0f, 64.0f,
                      59.0f, 55.0f, 51.0f, 45.0f, 44.0f, 39.0f, 26.0f, 25.0f, 25.0f, 22.0f, 20.0f, 18.0f, 18.0f,
                      16.0f, 14.0f, 10.0f, 8.0f, 5.0f, 5.0f, 2.0f, 0.0f, 0.0f };

  //public float[] speeds = {
  //10.0f, 10.0f, 10.0f, 10.0f, 10.0f, 10.0f, 10.0f,
  //20.0f, 20.0f, 20.0f, 20.0f, 20.0f, 20.0f, 20.0f,
  //30.0f, 30.0f, 30.0f, 30.0f, 30.0f, 30.0f, 30.0f,
  //40.0f, 40.0f, 40.0f, 40.0f, 40.0f, 40.0f, 40.0f,
  //50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f,
  //60.0f, 60.0f, 60.0f, 60.0f, 60.0f, 60.0f, 60.0f,
  //70.0f, 70.0f, 70.0f, 70.0f, 70.0f, 70.0f, 70.0f,
  //80.0f, 80.0f, 80.0f, 80.0f, 80.0f, 80.0f, 80.0f,
  //90.0f, 90.0f, 90.0f, 90.0f, 90.0f, 90.0f, 90.0f
  //};


  public Speedometer speedometer = new();

  private static readonly System.Timers.Timer timer = new(200);
  private static readonly System.Timers.Timer clock = new(1000);

  public static int i = 0;  //for looping through speeds array
  public int assistLevels;

  public Display1Page(Display1PageViewModel viewModel)
	{
		InitializeComponent();
    this.BindingContext = viewModel;

    timer.Elapsed += OnTimedEvent;
    timer.AutoReset = true;

    clock.Elapsed += OnClockEvent;
    clock.AutoReset = true;
    clock.Start();

    RideStop.IsVisible = false;

    i = 0;

    assistLevels = int.Parse(Preferences.Get("AssistLevelsNumberOfAssistLevels", "9"));
  }

  private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
  {
    ((Speedometer)Speedometer.Drawable).SpeedData(speeds[i]);
    
    Speedometer.Invalidate();

    i++;
    if (i == speeds.Length) i = 0;
  }

  private void OnClockEvent(Object source, System.Timers.ElapsedEventArgs e)
  {
    //Need this otherwise clock doesn't update
    MainThread.BeginInvokeOnMainThread(() =>
    {
      ClockT.Text = DateTime.Now.ToString("T");
    });

    if (showTripTime)
    {
      if (tripTimeStatus == "Running") tripTime += TimeSpan.FromSeconds(1);

      MainThread.BeginInvokeOnMainThread(() =>
      {
        TripT.Text = tripTime.ToString("T");
      });
    }
  }



  private void StartRide(object sender, EventArgs e)
  {
    if (!runSpeedo)
    {
      timer.Start();
      runSpeedo = true;
      RideStatus.Source = "pausesvgrepocom.svg";
      RideStop.IsVisible = true;
      //get current triptime, but only if tripTime == TimeSpan.Zero
      if (tripTime == TimeSpan.Zero) tripStartTime = DateTime.Now;
      showTripTime = true;
      tripTimeStatus = "Running";
    }
    else //pause
    {
      timer.Stop();
      runSpeedo = false;
      RideStatus.Source = "playsvgrepocom.svg";
      tripTimeStatus = "Paused";
    }
  }

  private void StopRide(object sender, EventArgs e)
  {
    timer.Stop();
    runSpeedo = false;
    RideStatus.Source = "playsvgrepocom.svg";
    RideStop.IsVisible = false;
    
    i = 0;
    ((Speedometer)Speedometer.Drawable).SpeedData(speeds[i]);
    Speedometer.Invalidate();

    tripTime = TimeSpan.Zero;
    MainThread.BeginInvokeOnMainThread(() =>
    {
      TripT.Text = tripTime.ToString("T");
    });

    showTripTime = false;
    tripTimeStatus = "Stopped";
    
  }

  public async void OnSwiped(object Sender, SwipedEventArgs e)
	{
		if (e.Direction == SwipeDirection.Left)
		{
      var navigationParameter = new Dictionary<string, object>
      {
        { "TestData", "Test Data" }
      };
      await Shell.Current.GoToAsync(nameof(Display2Page), true, navigationParameter);
    }
  }
  public void AssistDown(object sender, EventArgs args)
  {
    if (int.Parse(AssistLevel.Text) > 0) AssistLevel.Text = (int.Parse(AssistLevel.Text) - 1).ToString();
  }

  public void AssistUp(object sender, EventArgs args)
  {
    if (int.Parse(AssistLevel.Text) < assistLevels) AssistLevel.Text = (int.Parse(AssistLevel.Text) + 1).ToString();
  }
}