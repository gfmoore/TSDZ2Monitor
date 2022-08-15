namespace TSDZ2Monitor.Pages;

public partial class StartPage : ContentPage
{
  public static readonly System.Timers.Timer timer = new(10);

  public int buttonSize = 200;
  private bool makeBigger = true;
  private int makeBiggerCount = 0;
  private int startButtonFontSize = 30;
  private int fontSize;


  public StartPage(StartViewModel viewModel)
	{
		InitializeComponent();
    BindingContext = viewModel;

    timer.Elapsed += OnTimedEvent;
    timer.AutoReset = true;
  }

  protected override void OnAppearing()
  {
    base.OnAppearing();
    buttonSize = 200;

    StartButton.WidthRequest = buttonSize;
    StartButton.HeightRequest = buttonSize;
    fontSize = startButtonFontSize;
    StartButtonText.FontSize = startButtonFontSize;
    makeBigger = true;
    makeBiggerCount = 0;

  }

  public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
  {
    //make start button go up a little then down 
    if (makeBigger)
    {
      buttonSize += 2;
      makeBiggerCount += 1;
      if (makeBiggerCount == 20)
      {
        makeBigger = false;
      }
    }
    else
    {
      buttonSize -= 2;
      fontSize -= 1;
    }

    if (buttonSize <= 30)
    {
      timer.Stop();
      MainThread.BeginInvokeOnMainThread(() =>
      {
        NavigateDisplayPage();
      });
    }
    //animate start button
    MainThread.BeginInvokeOnMainThread(() =>
    {
      StartButton.WidthRequest = buttonSize;
      StartButton.HeightRequest = buttonSize;
      StartButtonText.FontSize -= 1;
    });
  }

  public async void NavigateDisplayPage()
  {
    var navigationParameter = new Dictionary<string, object>
    {
      { "TestData", "Test Data" }
    };
    await Shell.Current.GoToAsync(nameof(Display1Page), true, navigationParameter);
  }

  public void StartMotor(object sender, EventArgs args)
  {
    Debug.WriteLine("Start Motor");
    timer.Start();
  }

}