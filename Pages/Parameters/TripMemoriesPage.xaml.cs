namespace TSDZ2Monitor.Pages.Parameters;

public partial class TripMemoriesPage : ContentPage
{
  public bool checkInput = false;

  //TODO Need to check hours passed to see if A or B should reset
  public TripMemoriesPage()
	{
		InitializeComponent();

    checkInput = false;  //stop activating text changed events
    TripMemoriesOdometer.Text = Preferences.Get("TripMemoriesOdometer", "0");
    TripMemoriesTripA.Text = Preferences.Get("TripMemoriesTripA", "0");
    TripMemoriesTripB.Text = Preferences.Get("TripMemoriesTripB", "0");

    if (Preferences.Get("TripMemoriesTripAAutoReset", "true") == "true")
    {
      TripMemoriesTripAAutoReset.IsToggled = true;
      TripMemoriesTripAAutoReset.ThumbColor = Colors.Green;
    }
    else
    {
      TripMemoriesTripAAutoReset.IsToggled = false;
      TripMemoriesTripAAutoReset.ThumbColor = Colors.Red;
    }

    TripMemoriesTripAAutoResetHours.Text = Preferences.Get("TripMemoriesTripAAutoResetHours", "24");

    if (Preferences.Get("TripMemoriesTripBAutoReset", "true") == "true")
    {
      TripMemoriesTripBAutoReset.IsToggled = true;
      TripMemoriesTripBAutoReset.ThumbColor = Colors.Green;
    }
    else
    {
      TripMemoriesTripBAutoReset.IsToggled = false;
      TripMemoriesTripBAutoReset.ThumbColor = Colors.Red;
    }

    TripMemoriesTripBAutoResetHours.Text = Preferences.Get("TripMemoriesTripBAutoResetHours", "168");

  }

  //-------Trip memories Odometer------------------------------------------------
   private async void OnTripMemoriesOdometerLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Odometer reading, reset with red button", "OK");
  }
  private async void OnTripMemoriesOdometerReset(object sender, EventArgs e)
  {
    bool doit = await DisplayAlert("Warning", "Reset Odometer? There is no going back!", "Yes", "Cancel");
    if (!doit) return;
    TripMemoriesOdometer.Text = "0";
    Preferences.Set("TripMemoriesOdometer", "0");
  }


  //-------Trip memories A------------------------------------------------
  private async void OnTripMemoriesTripALabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Trip A reading, reset with red button", "OK");
  }

  private async void OnTripMemoriesTripAReset(object sender, EventArgs e)
  {
    bool doit = await DisplayAlert("Warning", "Reset TripA? There is no going back!", "Yes", "Cancel");
    if (!doit) return;
    TripMemoriesTripA.Text = "0";
    Preferences.Set("TripMemoriesTripA", "0");
  }

  //-------Trip memories B------------------------------------------------
  private async void OnTripMemoriesTripBLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "TripB reading, reset with red button", "OK");
  }

  private async void OnTripMemoriesTripBReset(object sender, EventArgs e)
  {
    bool doit = await DisplayAlert("Warning", "Reset TripB? There is no going back!", "Yes", "Cancel");
    if (!doit) return;
    TripMemoriesTripB.Text = "0";
    Preferences.Set("TripMemoriesTripB", "0");
  }


  //-------Trip Memories A Auto Reset------------------------------------------------
  private void TripMemoriesTripAAutoReset_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (TripMemoriesTripAAutoReset.IsToggled)
    {
      Preferences.Set("TripMemoriesTripAAutoReset", "true");
      TripMemoriesTripAAutoReset.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("TripMemoriesTripAAutoReset", "false");
      TripMemoriesTripAAutoReset.ThumbColor = Colors.Red;
    }
  }

  private async void OnTripMemoriesTripAAutoResetLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Allow Trip A to reset", "OK");
  }


  //-------Trip Memories A AutoReset Hours------------------------------------------------
  private void TripMemoriesTripAAutoResetHours_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TripMemoriesTripAAutoResetHours.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TripMemoriesTripAAutoResetHours.TextColor = Colors.LightGreen;

    if (TripMemoriesTripAAutoResetHours.TextColor != Colors.Red && TripMemoriesTripAAutoResetHours.Text.Length != 0)
    {
      Preferences.Set("TripMemoriesTripAAutoResetHours", TripMemoriesTripAAutoResetHours.Text);
    }
  }

  private void TripMemoriesTripAAutoResetHours_Completed(object sender, EventArgs e)
  {
    if (TripMemoriesTripAAutoResetHours.TextColor != Colors.Red && TripMemoriesTripAAutoResetHours.Text.Length != 0)
    {
      Preferences.Set("TripMemoriesTripAAutoResetHours", TripMemoriesTripAAutoResetHours.Text);
    }

    //dismiss keyboard
    TripMemoriesTripAAutoResetHours.IsEnabled = false;
    TripMemoriesTripAAutoResetHours.IsEnabled = true;
  }

  private async void OnTripMemoriesTripAAutoResetHoursLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The number of hours before reset.", "OK");
  }


  //-------Trip Memories B Auto Reset------------------------------------------------
  private void TripMemoriesTripBAutoReset_Toggled(object sender, EventArgs e)
  {
    //Write to preferences
    if (TripMemoriesTripBAutoReset.IsToggled)
    {
      Preferences.Set("TripMemoriesTripBAutoReset", "true");
      TripMemoriesTripBAutoReset.ThumbColor = Colors.Green;
    }
    else
    {
      Preferences.Set("TripMemoriesTripBAutoReset", "false");
      TripMemoriesTripBAutoReset.ThumbColor = Colors.Red;
    }
  }

  private async void OnTripMemoriesTripBAutoResetLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "Allow Trip B to reset", "OK");
  }

  //-------Trip Memories B AutoReset Hours------------------------------------------------
  private void TripMemoriesTripBAutoResetHours_TextChanged(object sender, TextChangedEventArgs e)
  {
    if (!checkInput) return;

    TripMemoriesTripBAutoResetHours.TextColor = Colors.Red;
    if (CheckNumeric(e.NewTextValue)) TripMemoriesTripBAutoResetHours.TextColor = Colors.LightGreen;

    if (TripMemoriesTripBAutoResetHours.TextColor != Colors.Red && TripMemoriesTripBAutoResetHours.Text.Length != 0)
    {
      Preferences.Set("TripMemoriesTripBAutoResetHours", TripMemoriesTripBAutoResetHours.Text);
    }
  }

  private void TripMemoriesTripBAutoResetHours_Completed(object sender, EventArgs e)
  {
    if (TripMemoriesTripBAutoResetHours.TextColor != Colors.Red && TripMemoriesTripBAutoResetHours.Text.Length != 0)
    {
      Preferences.Set("TripMemoriesTripBAutoResetHours", TripMemoriesTripBAutoResetHours.Text);
    }

    //dismiss keyboard
    TripMemoriesTripBAutoResetHours.IsEnabled = false;
    TripMemoriesTripBAutoResetHours.IsEnabled = true;
  }

  private async void OnTripMemoriesTripBAutoResetHoursLabelTapped(object sender, EventArgs e)
  {
    await DisplayAlert("Information", "The number of hours before reset.", "OK");
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