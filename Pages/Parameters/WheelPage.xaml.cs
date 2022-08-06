namespace TSDZ2Monitor.Pages.Parameters;

public partial class WheelPage : ContentPage
{
  public bool checkInput = false;
  public WheelPage()
	{
		InitializeComponent();

    checkInput = false;  //stop activating text changed events
    WheelMaxSpeed.Text = Preferences.Get("WheelMaxSpeed", "50");
    WheelCircumference.Text = Preferences.Get("WheelCircumference", "2073");
    checkInput = true;
  }

  //TODO allow for metric/imperial
  //TODO Allow diameter

  //-------Wheel Max Speed------------------------------------------------
  private void WheelMaxSpeed_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    WheelMaxSpeed.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) WheelMaxSpeed.TextColor = Colors.LightGreen;

    if (WheelMaxSpeed.TextColor != Colors.Red && WheelMaxSpeed.Text.Length != 0)
    {
      Preferences.Set("WheelMaxSpeed", WheelMaxSpeed.Text);
    }
  }

  private void WheelMaxSpeed_Completed(object sender, EventArgs e)
  {
    if (WheelMaxSpeed.TextColor != Colors.Red && WheelMaxSpeed.Text.Length != 0)
    {
      Preferences.Set("WheelMaxSpeed", WheelMaxSpeed.Text);
    }

    //dismiss keyboard
    WheelMaxSpeed.IsEnabled = false;
    WheelMaxSpeed.IsEnabled = true;
  }

  private async void OnWheelMaxSpeedLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enter the speed limit from where the motor will fade out power from.", "OK");
  }



  //-------Wheel Circumference------------------------------------------------
  private void WheelCircumference_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    WheelCircumference.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) WheelCircumference.TextColor = Colors.LightGreen;

    if (WheelCircumference.TextColor != Colors.Red && WheelCircumference.Text.Length != 0)
    {
      Preferences.Set("WheelCircumference", WheelCircumference.Text);
    }
  }

  private void WheelCircumference_Completed(object sender, EventArgs e)
  {
    if (WheelCircumference.TextColor != Colors.Red && WheelCircumference.Text.Length != 0)
    {
      Preferences.Set("WheelCircumference", WheelCircumference.Text);
    }

    //dismiss keyboard
    WheelCircumference.IsEnabled = false;
    WheelCircumference.IsEnabled = true;
  }

  private async void OnWheelCircumferenceLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Enter your wheel circumference so that speed and distance are correctly calculated.", "OK");
  }


  //----------Helper functions--------------------------------------
  public static bool CheckNumeric(string t)
  {
    bool validNumber = true;
    if (!Regex.IsMatch(t, @"^\d+$"))
    {
      validNumber = false;
    }
    //no leading 0
    if (t.Length > 1 && t[0] == '0')
    {
      validNumber = false;
    }
    return validNumber;
  }
}